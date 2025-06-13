using Client.GuiController;
using Client;
using Common.Communication;
using Client.Forms;

internal abstract class BaseEntityService<T, TForm, TCrudForm>
    where T : class, ICrudEntity, new()
    where TForm : Form, IForm, new()
    where TCrudForm : Form, ICrudForm<T>, new()
{
    protected abstract Operation CreateOperation { get; }
    protected abstract Operation UpdateOperation { get; }
    protected abstract Operation DeleteOperation { get; }
    protected abstract Operation SearchOperation { get; }

    protected abstract TCrudForm GetCrudForm();
    protected abstract TForm GetSearchForm();
    protected abstract T CreateEntityFromForm(TCrudForm form);
    protected abstract void FillFormWithEntity(TCrudForm form, T entity);
    protected abstract string GetSearchCriteria(TForm form);
    protected abstract void BindSearchResults(TForm form, List<T> results);

    public void Kreiraj()
    {
        try
        {
            var form = GetCrudForm();
            if (!ValidateForm(form)) throw new Exception("Sva obavezna polja moraju biti popunjena.");

            T entity = CreateEntityFromForm(form);

            var response = Communication.Instance.SendRequest<T, T>(entity, CreateOperation);
            CheckResponse(response);

            MessageBox.Show("Uspešno sačuvano.");
            FormManager.Instance.Close<TCrudForm>();
        }
        catch (Exception ex)
        {
            ShowError("Greška prilikom kreiranja.", ex);
        }
    }

    public void Promeni()
    {
        try
        {
            var form = GetCrudForm();
            if (!ValidateForm(form)) throw new Exception("Sva obavezna polja moraju biti popunjena.");

            T entity = CreateEntityFromForm(form);

            var response = Communication.Instance.SendRequest<T, T>(entity, UpdateOperation);
            CheckResponse(response);

            MessageBox.Show("Uspešno izmenjeno.");
            FormManager.Instance.Close<TCrudForm>();
        }
        catch (Exception ex)
        {
            ShowError("Greška prilikom izmene.", ex);
        }
    }

    public void Obrisi()
    {
        try
        {
            var form = GetCrudForm();

            if (form.Tag is not ICrudEntity entityFromTag)
                throw new Exception("Nema entiteta za brisanje.");

            var entity = new T { Id = ((ICrudEntity)form.Tag).Id };

            var response = Communication.Instance.SendRequest<T, T>(entity, DeleteOperation);
            CheckResponse(response);

            MessageBox.Show("Uspešno obrisano.");
            FormManager.Instance.Close<TCrudForm>();
        }
        catch (Exception ex)
        {
            ShowError("Greška prilikom brisanja.", ex);
        }
    }

    public List<T> Pretrazi()
    {
        try
        {
            var form = GetSearchForm();
            string criteria = GetSearchCriteria(form);

            var response = Communication.Instance.SendRequestList<string, T>(criteria, SearchOperation);
            CheckResponse(response);

            var result = response.Result as List<T>;
            BindSearchResults(form, result);

            MessageBox.Show("Pretraga uspešna.");
            return result;
        }
        catch (Exception ex)
        {
            ShowError("Greška prilikom pretrage.", ex);
            return null;
        }
    }

    public void PrikaziDetalje()
    {
        try
        {
            var form = GetSearchForm();
            var selected = GetSelectedEntity(form);

            MessageBox.Show("Entitet je pronađen.");

            FormManager.Instance.Open<TCrudForm>(form =>
            {
                form.Tag = selected;
                FillFormWithEntity(form, selected);
                form.FormClosed += (s, e) => Pretrazi();
            });
        }
        catch (Exception ex)
        {
            ShowError("Greška pri prikazu detalja.", ex);
        }
    }

    protected virtual bool ValidateForm(Form form) => (form as ICrudForm<T>)?.Validation() == true;

    protected virtual T GetSelectedEntity(TForm form)
    {
        var dgv = form.Controls.OfType<DataGridView>().FirstOrDefault();
        if (dgv == null || dgv.SelectedRows.Count == 0)
            throw new Exception("Morate selektovati red.");

        return dgv.SelectedRows[0].DataBoundItem as T ?? throw new Exception("Greška u izboru reda.");
    }

    protected virtual void CheckResponse(Response response)
    {
        if (response.ExceptionType != null)
            throw new Exception(response.ExceptionMessage);
    }

    protected virtual void ShowError(string message, Exception ex)
    {
        MessageBox.Show($"{message}\n\n({ex.Message})", "Greška");
    }
}
