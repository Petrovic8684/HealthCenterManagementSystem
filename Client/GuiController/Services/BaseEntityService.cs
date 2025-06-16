using Client.GuiController;
using Client;
using Common.Communication;
using Client.Forms;

internal abstract class BaseEntityService<T, TForm, TCrudForm>
    where T : class, ICrudEntity, new()
    where TForm : Form, IForm<T>, new()
    where TCrudForm : Form, ICrudForm<T>, new()
{
    protected abstract Operation CreateOperation { get; }
    protected abstract Operation UpdateOperation { get; }
    protected abstract Operation DeleteOperation { get; }
    protected abstract Operation SearchOperation { get; }
    protected abstract Operation RetreiveAllListOperation { get; }

    protected abstract TCrudForm GetCrudForm();
    protected abstract List<T> BuildListResults(TForm form);
    protected abstract TForm GetSearchForm();
    protected abstract T CreateEntityFromForm(TCrudForm form);
    protected abstract void FillFormWithEntity(TCrudForm form, T entity);
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

            MessageBox.Show("Sistem je zapamtio " + new T().ImeKlaseAkuzativJednine + ".");
            FormManager.Instance.Close<TCrudForm>();
        }
        catch (Exception ex)
        {
            ShowError("Sistem ne može da zapamti " + new T().ImeKlaseAkuzativJednine + ".", ex);
        }
    }

    public void Promeni()
    {
        try
        {
            var form = GetCrudForm();
            if (!ValidateForm(form)) throw new Exception("Sva obavezna polja moraju biti popunjena.");

            T entity = CreateEntityFromForm(form);

            ValidateBeforeOperation(entity);

            var response = Communication.Instance.SendRequest<T, T>(entity, UpdateOperation);
            CheckResponse(response);

            MessageBox.Show("Sistem je zapamtio " + new T().ImeKlaseAkuzativJednine + ".");
            FormManager.Instance.Close<TCrudForm>();
        }
        catch (Exception ex)
        {
            ShowError("Sistem ne može da zapamti " + new T().ImeKlaseAkuzativJednine + ".", ex);
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

            ValidateBeforeOperation(entity);

            var response = Communication.Instance.SendRequest<T, T>(entity, DeleteOperation);
            CheckResponse(response);

            MessageBox.Show("Sistem je obrisao " + new T().ImeKlaseAkuzativJednine + ".");
            FormManager.Instance.Close<TCrudForm>();
        }
        catch (Exception ex)
        {
            ShowError("Sistem ne može da obriše " + new T().ImeKlaseAkuzativJednine + ".", ex);
        }
    }

    public void Pretrazi()
    {
        try
        {
            var form = GetSearchForm();
            var selected = GetSelectedEntity(form);

            var response = Communication.Instance.SendRequest<T, T>(selected, SearchOperation);
            CheckResponse(response);

            var result = response.Result as T;

            MessageBox.Show("Sistem je pronašao " + result.ImeKlaseAkuzativJednine + ".");

            FormManager.Instance.Open<TCrudForm>(form =>
            {
                form.Tag = selected;
                FillFormWithEntity(form, selected);
                form.FormClosed += (s, e) => VratiListuSvi();
            });
        }
        catch (Exception ex)
        {
            ShowError("Sistem ne može da nađe " + new T().ImeKlaseAkuzativJednine + ".", ex);
        }
    }

    public virtual List<T> VratiListuSvi()
    {
        try
        {
            var form = GetSearchForm();

            var response = Communication.Instance.SendRequestList<object, T>(null, RetreiveAllListOperation);
            CheckResponse(response);

            var result = response.Result as List<T>;
            BindSearchResults(form, result);

            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public List<T> VratiListu(bool showMessages = true)
    {
        try
        {
            var form = GetSearchForm();
            var results = BuildListResults(form);

            if (showMessages)
            {
                if (results == null || results.Count == 0)
                    MessageBox.Show("Sistem ne može da nađe " + new T().ImeKlaseAkuzativMnozine + " po zadatim kriterijumima.");
                else
                    MessageBox.Show("Sistem je našao " + new T().ImeKlaseAkuzativMnozine + " po zadatim kriterijumima.");
            }

            BindSearchResults(form, results);
            return results;
        }
        catch (Exception ex)
        {
            if (showMessages)
                ShowError("Sistem ne može da nađe " + new T().ImeKlaseAkuzativMnozine + " po zadatim kriterijumima.", ex);
            return null;
        }
    }

    protected virtual bool ValidateForm(Form form) => (form as ICrudForm<T>)?.Validation() == true;

    protected virtual void ValidateBeforeOperation(T entity) {  }

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
