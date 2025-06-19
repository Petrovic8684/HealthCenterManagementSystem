using Client;
using Common.Communication;
using Client.Forms;
using System.Windows.Forms;
using Client.GuiController;

internal abstract class BaseEntityService<T, TForm, TCrudForm>
    where T : class, ICrudEntity, new()
    where TForm : Form, new()
    where TCrudForm : Form, ICrudForm<T>, new()
{
    protected abstract Operation CreateOperation { get; }
    protected abstract Operation UpdateOperation { get; }
    protected abstract Operation DeleteOperation { get; }
    protected abstract Operation SearchOperation { get; }
    protected abstract Operation RetreiveAllListOperation { get; }

    protected abstract TCrudForm GetCrudForm();
    protected abstract void CloseCrudForm();
    protected abstract List<T> BuildListResults(TForm form);
    protected abstract TForm GetForm();
    protected abstract T CreateEntityFromForm(TCrudForm form);
    protected abstract void FillFormWithEntity(TCrudForm form, T entity);
    protected abstract void BindSearchResults(TForm form, List<T> results);

    public void Create()
    {
        ICrudEntity? createdEntity = null;

        try
        {
            var entity = new T();
            var response = Communication.Instance.SendRequestGetObject<T, T>(entity, CreateOperation);
            CheckResponse(response);

            createdEntity = (ICrudEntity)response.Result;

            ShowMessage("Sistem je kreirao " + createdEntity.ClassNameAccusativeSingular + ".");

            FormManager.Instance.Open<TCrudForm>(form =>
            {
                form.Tag = createdEntity;
                form.FormClosed += (s, e) => FetchListAll();
            }, true);
        }
        catch (Exception ex)
        {
            ShowMessage("Sistem ne može da kreira " + new T().ClassNameAccusativeSingular + ".\n\n" + ex.Message, "Greška");

            if (createdEntity != null)
            {
                try
                {
                    Communication.Instance.SendRequestGetObject<T, T>(
                        (T)new T { Id = createdEntity.Id },
                        DeleteOperation
                    );

                    ShowMessage("Sistem je obrisao neuspešno kreirani entitet " + new T().ClassNameAccusativeSingular + ".");
                }
                catch (Exception deleteEx)
                {
                    ShowMessage("Sistem ne može da obriše neuspešno kreirani entitet." + new T().ClassNameAccusativeSingular + " Molimo obrišite entitet ručno.\n\n" + deleteEx.Message, "Greška");
                }
            }

            CloseCrudForm();
        }
    }

    public void Save()
    {
        try
        {
            var form = GetCrudForm();
            if (!ValidateForm(form)) throw new Exception("Sva obavezna polja moraju biti popunjena.");

            T entity = CreateEntityFromForm(form);

            //ValidateBeforeOperation(entity);

            entity.Id = ((ICrudEntity)form.Tag).Id;

            var response = Communication.Instance.SendRequestGetObject<T, T>(entity, UpdateOperation);
            CheckResponse(response);

            ShowMessage("Sistem je zapamtio " + new T().ClassNameAccusativeSingular + ".");
            CloseCrudForm();
        }
        catch (Exception ex)
        {
            ShowMessage("Sistem ne može da zapamti " + new T().ClassNameAccusativeSingular + ".\n\n" + ex.Message, "Greška");
        }
    }

    public void Delete()
    {
        try
        {
            var form = GetCrudForm();
            var entity = new T { Id = ((ICrudEntity)form.Tag).Id };

            //ValidateBeforeOperation(entity);

            var response = Communication.Instance.SendRequestGetObject<T, T>(entity, DeleteOperation);
            CheckResponse(response);

            ShowMessage("Sistem je obrisao " + new T().ClassNameAccusativeSingular + ".");
        }
        catch (Exception ex)
        {
            ShowMessage("Sistem ne može da obriše " + new T().ClassNameAccusativeSingular + ".\n\n" + ex.Message, "Greška");
        }
        finally
        {
            CloseCrudForm();
        }
    }

    public void Read()
    {
        try
        {
            var form = GetForm();
            var selected = GetSelectedEntity(form);

            var response = Communication.Instance.SendRequestGetObject<T, T>(selected, SearchOperation);
            CheckResponse(response);

            var result = response.Result as T;

            ShowMessage("Sistem je pronašao " + result.ClassNameAccusativeSingular + ".");

            FormManager.Instance.Open<TCrudForm>(form =>
            {
                form.Tag = selected;
                FillFormWithEntity(form, selected);
                form.FormClosed += (s, e) => FetchListAll();
            }, true);
        }
        catch (Exception ex)
        {
            ShowMessage("Sistem ne može da pronađe " + new T().ClassNameAccusativeSingular + ".\n\n" + ex.Message, "Greška");
        }
    }

    public virtual List<T> FetchListAll(bool shouldBind = true)
    {
        try
        {
            var form = GetForm();

            var response = Communication.Instance.SendRequestGetList<object, T>(null, RetreiveAllListOperation);
            CheckResponse(response);

            var result = response.Result as List<T>;
            
            if(shouldBind == true)
                BindSearchResults(form, result);

            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public List<T> FetchList(bool showMessages = true)
    {
        try
        {
            var form = GetForm();
            var results = BuildListResults(form);

            if (showMessages)
            {
                if (results == null || results.Count == 0) ShowMessage("Sistem ne može da nađe " + new T().ClassNameAccusativePlural + " po zadatim kriterijumima.");
                else ShowMessage("Sistem je našao " + new T().ClassNameAccusativePlural + " po zadatim kriterijumima.");
            }

            BindSearchResults(form, results);
            return results;
        }
        catch (Exception ex)
        {
            if (showMessages) ShowMessage("Sistem ne može da nađe " + new T().ClassNameAccusativePlural + " po zadatim kriterijumima." + "\n\n" + ex.Message, "Greška");
            return null;
        }
    }

    protected virtual bool ValidateForm(Form form) => (form as ICrudForm<T>)?.Validation() == true;

    protected virtual void ValidateBeforeOperation(T entity) {  }

    protected virtual T GetSelectedEntity(TForm form)
    {
        var dgv = form.Controls.OfType<DataGridView>().FirstOrDefault();
        if (dgv == null || dgv.SelectedRows.Count == 0)
            throw new Exception("Niste izabrali nijedan red.");

        return dgv.SelectedRows[0].DataBoundItem as T ?? throw new Exception("Greška u izboru reda.");
    }

    protected virtual void CheckResponse(Response response)
    {
        if (response.ExceptionType != null)
            throw new Exception(response.ExceptionMessage);
    }

    protected virtual void ShowMessage(string message, string title = null, Form owner = null)
    {
        if (owner != null && title != null)
        {
            MessageBox.Show(owner, message, title);
            return;
        }

        if (owner != null)
        {
            MessageBox.Show(owner, message);
            return;
        }

        if (title != null)
        {
            MessageBox.Show(message, title);
            return;
        }

        MessageBox.Show(message);
    }
}
