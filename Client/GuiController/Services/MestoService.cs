using Common.Communication;
using Common.Domain;
using Client.Forms;
using Client.GuiController.Criteria;

namespace Client.GuiController.Services
{
    internal class MestoService : BaseEntityService<Mesto, FrmMesto, FrmMestoCRUD>
    {
        protected override Operation CreateOperation => Operation.KreirajMesto;
        protected override Operation UpdateOperation => Operation.PromeniMesto;
        protected override Operation DeleteOperation => Operation.ObrisiMesto;
        protected override Operation SearchOperation => Operation.PretraziMesto;
        protected override Operation RetreiveAllListOperation => Operation.VratiListuSviMesto;
        protected override FrmMesto GetForm() => FormManager.Instance.Get<FrmMesto>() ?? new FrmMesto();
        protected override FrmMestoCRUD GetCrudForm() => FormManager.Instance.Get<FrmMestoCRUD>() ?? FormManager.Instance.Open<FrmMestoCRUD>(form => form.FormClosed += (s, e) => FetchListAll(), true);
        protected override void CloseCrudForm() => FormManager.Instance.Close<FrmMestoCRUD>();

        protected override Mesto CreateEntityFromForm(FrmMestoCRUD form) => new()
        {
            Id = form.Mesto?.Id ?? 0,
            Naziv = form.tbNaziv.Text.Trim(),
            PostanskiBroj = form.tbPostanskiBroj.Text.Trim(),
        };

        protected override void FillFormWithEntity(FrmMestoCRUD form, Mesto entity)
        {
            form.ShowDetails(entity);
        }

        protected override void BindSearchResults(FrmMesto form, List<Mesto> results)
        {
            form.dgvMesta.DataSource = results;

            foreach (DataGridViewColumn column in form.dgvMesta.Columns)
            {
                column.Visible = column.Name == nameof(Mesto.Id)
                              || column.Name == nameof(Mesto.Naziv)
                              || column.Name == nameof(Mesto.PostanskiBroj);
            }
        }

        protected override List<Mesto> BuildListResults(FrmMesto form)
        {
            return new MestoCriteriaBuilder()
                .WithNaziv(form.tbNaziv.Text)
                .WithPostanskiBroj(form.tbPostanskiBroj.Text)
                .Build();
        }
    }
}
