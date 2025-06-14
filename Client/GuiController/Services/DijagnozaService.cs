using Client.GuiController;
using Client;
using Common.Domain;
using Common.Communication;

internal class DijagnozaService : BaseEntityService<Dijagnoza, FrmDijagnoza, FrmDijagnozaCRUD>
{
    protected override Operation CreateOperation => Operation.KreirajDijagnoza;
    protected override Operation UpdateOperation => Operation.PromeniDijagnoza;
    protected override Operation DeleteOperation => Operation.ObrisiDijagnoza;
    protected override Operation SearchOperation => Operation.PretraziDijagnoza;

    protected override FrmDijagnoza GetSearchForm() => FormManager.Instance.Get<FrmDijagnoza>() ?? new FrmDijagnoza();
    protected override FrmDijagnozaCRUD GetCrudForm() => FormManager.Instance.Get<FrmDijagnozaCRUD>();

    protected override Dijagnoza CreateEntityFromForm(FrmDijagnozaCRUD form) => new()
    {
        Id = form.Dijagnoza?.Id ?? 0,
        Naziv = form.tbNaziv.Text.Trim(),
        Opis = form.tbOpis.Text.Trim(),
        BazniSkor = Convert.ToDouble(form.tbBazniSkor.Text.Trim()),
    };

    protected override void FillFormWithEntity(FrmDijagnozaCRUD form, Dijagnoza entity)
    {
        form.PrikaziDetalje(entity);
    }

    protected override Dijagnoza GetSearchCriteria(FrmDijagnoza form) => form.ConstructCriteria();

    protected override void BindSearchResults(FrmDijagnoza form, List<Dijagnoza> results)
    {
        form.dgvDijagnoze.DataSource = results;

        foreach (DataGridViewColumn column in form.dgvDijagnoze.Columns)
            column.Visible = column.Name is nameof(Dijagnoza.Id) or nameof(Dijagnoza.Naziv) or nameof(Dijagnoza.Opis) or nameof(Dijagnoza.BazniSkor);
    }
}
