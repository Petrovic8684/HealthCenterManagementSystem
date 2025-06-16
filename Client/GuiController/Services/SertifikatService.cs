using Common.Communication;
using Common.Domain;
using Client.Forms;
using Client.GuiController.Criteria;

namespace Client.GuiController.Services
{
    internal class SertifikatService : BaseEntityService<Sertifikat, FrmSertifikat, FrmSertifikatCRUD>
    {
        protected override Operation CreateOperation => Operation.UbaciSertifikat;
        protected override Operation UpdateOperation => Operation.PromeniSertifikat;
        protected override Operation DeleteOperation => Operation.ObrisiSertifikat;
        protected override Operation SearchOperation => Operation.PretraziSertifikat;
        protected override Operation RetreiveAllListOperation => Operation.VratiListuSviSertifikat;
        protected override FrmSertifikat GetSearchForm() => FormManager.Instance.Get<FrmSertifikat>() ?? new FrmSertifikat();

        protected override FrmSertifikatCRUD GetCrudForm() => FormManager.Instance.Get<FrmSertifikatCRUD>();

        protected override Sertifikat CreateEntityFromForm(FrmSertifikatCRUD form) => new()
        {
            Id = form.Sertifikat?.Id ?? 0,
            Opis = form.tbOpis.Text.Trim()
        };

        protected override void FillFormWithEntity(FrmSertifikatCRUD form, Sertifikat entity)
        {
            form.PrikaziDetalje(entity);
        }

        protected override void BindSearchResults(FrmSertifikat form, List<Sertifikat> results)
        {
            form.dgvSertifikati.DataSource = results;

            foreach (DataGridViewColumn column in form.dgvSertifikati.Columns)
            {
                column.Visible = column.Name == nameof(Sertifikat.Id) || column.Name == nameof(Sertifikat.Opis);
            }
        }

        protected override List<Sertifikat> BuildListResults(FrmSertifikat form)
        {
            return new SertifikatCriteriaBuilder()
                .WithOpis(form.tbOpis.Text)
                .Build();
        }
    }
}
