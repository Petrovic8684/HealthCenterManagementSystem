using Common.Communication;
using Common.Domain;
using Client.Forms;
using Client.GuiController.Criteria;

namespace Client.GuiController.Services
{
    internal class PacijentService : BaseEntityService<Pacijent, FrmPacijent, FrmPacijentCRUD>
    {
        protected override Operation CreateOperation => Operation.KreirajPacijent;
        protected override Operation UpdateOperation => Operation.PromeniPacijent;
        protected override Operation DeleteOperation => Operation.ObrisiPacijent;
        protected override Operation SearchOperation => Operation.PretraziPacijent;
        protected override Operation RetreiveAllListOperation => Operation.VratiListuSviPacijent;
        protected override FrmPacijent GetForm() => FormManager.Instance.Get<FrmPacijent>() ?? new FrmPacijent();
        protected override FrmPacijentCRUD GetCrudForm() => FormManager.Instance.Get<FrmPacijentCRUD>() ?? FormManager.Instance.Open<FrmPacijentCRUD>(form => form.FormClosed += (s, e) => FetchListAll(), true);
        protected override void CloseCrudForm() => FormManager.Instance.Close<FrmPacijentCRUD>();

        protected override Pacijent CreateEntityFromForm(FrmPacijentCRUD form) => new()
        {
            Id = form.Pacijent?.Id ?? 0,
            Ime = form.tbIme.Text.Trim(),
            Prezime = form.tbPrezime.Text.Trim(),
            Email = form.tbEmail.Text.Trim(),
            Mesto = (Mesto)form.cbMesta.SelectedItem
        };

        protected override void FillFormWithEntity(FrmPacijentCRUD form, Pacijent entity)
        {
            form.ShowDetails(entity);
        }

        protected override void BindSearchResults(FrmPacijent form, List<Pacijent> results)
        {
            form.dgvPacijenti.DataSource = results;

            foreach (DataGridViewColumn col in form.dgvPacijenti.Columns)
            {
                col.Visible = col.Name == nameof(Pacijent.Id)
                           || col.Name == nameof(Pacijent.Ime)
                           || col.Name == nameof(Pacijent.Prezime)
                           || col.Name == nameof(Pacijent.Email)
                           || col.Name == nameof(Pacijent.Mesto);
            }
        }

        protected override List<Pacijent> BuildListResults(FrmPacijent form)
        {
            return new PacijentCriteriaBuilder()
                .WithIme(form.tbIme.Text)
                .WithPrezime(form.tbPrezime.Text)
                .WithMesto((Mesto)form.cbMesta.SelectedItem)
                .Build();
        }
    }
}
