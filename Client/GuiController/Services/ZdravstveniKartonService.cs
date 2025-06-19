using Client;
using Common.Domain;
using Common.Communication;
using Client.GuiController.Criteria;
using Client.Forms;

internal class ZdravstveniKartonService : BaseEntityService<ZdravstveniKarton, FrmZdravstveniKarton, FrmZdravstveniKartonCRUD>
{
    protected override Operation CreateOperation => Operation.KreirajZdravstveniKarton;
    protected override Operation UpdateOperation => Operation.PromeniZdravstveniKarton;
    protected override Operation DeleteOperation => Operation.ObrisiZdravstveniKarton;
    protected override Operation SearchOperation => Operation.PretraziZdravstveniKarton;
    protected override Operation RetreiveAllListOperation => Operation.None;
    protected override FrmZdravstveniKarton GetForm() => FormManager.Instance.Get<FrmZdravstveniKarton>() ?? new FrmZdravstveniKarton();
    protected override FrmZdravstveniKartonCRUD GetCrudForm() => FormManager.Instance.Get<FrmZdravstveniKartonCRUD>() ?? FormManager.Instance.Open<FrmZdravstveniKartonCRUD>(form => form.FormClosed += (s, e) => FetchListAll(), true);
    protected override void CloseCrudForm() => FormManager.Instance.Close<FrmZdravstveniKartonCRUD>();

    protected override ZdravstveniKarton CreateEntityFromForm(FrmZdravstveniKartonCRUD form) => new ZdravstveniKarton
    {
        Id = form.ZdravstveniKarton?.Id ?? 0,
        Lekar = (Lekar)form.cbLekari.SelectedItem,
        Pacijent = (Pacijent)form.cbPacijenti.SelectedItem,
        Napomena = form.tbNapomena.Text.Trim(),
        DatumOtvaranja = form.ZdravstveniKarton?.DatumOtvaranja ?? DateTime.Now,
        Stavke = form.lbStavke.Items.Cast<StavkaZdravstvenogKartona>().ToList()
    };

    protected override void FillFormWithEntity(FrmZdravstveniKartonCRUD form, ZdravstveniKarton entity)
    {
        form.ShowDetails(entity);
    }

    protected override void BindSearchResults(FrmZdravstveniKarton form, List<ZdravstveniKarton> results)
    {
        form.dgvZdravstveniKartoni.DataSource = results;

        foreach (DataGridViewColumn col in form.dgvZdravstveniKartoni.Columns)
            col.Visible = col.Name == nameof(ZdravstveniKarton.Id)
                       || col.Name == nameof(ZdravstveniKarton.DatumOtvaranja)
                       || col.Name == nameof(ZdravstveniKarton.Napomena)
                       || col.Name == nameof(ZdravstveniKarton.UkupniSkor)
                       || col.Name == nameof(ZdravstveniKarton.Stanje)
                       || col.Name == nameof(ZdravstveniKarton.Lekar)
                       || col.Name == nameof(ZdravstveniKarton.Pacijent);
    }

    private List<StavkaZdravstvenogKartona> GetStavkaList(ListBox lb)
    {
        return lb.DataSource as List<StavkaZdravstvenogKartona> ?? lb.Items.OfType<StavkaZdravstvenogKartona>().ToList();
    }

    public override List<ZdravstveniKarton> FetchListAll(bool shouldBind = true) => FetchList(false);

    internal void AddStavka()
    {
        try
        {
            FrmZdravstveniKartonCRUD frm = FormManager.Instance.Get<FrmZdravstveniKartonCRUD>();

            if (frm.cbDijagnoze.SelectedItem == null || frm.cbDijagnoze.SelectedIndex == 0)
                throw new Exception("Greška pri odabiru dijagnoze.");

            if (!FormValidator.Instance.IsValidDoubleGreaterThanZero(frm.tbPonder.Text.Trim()))
                throw new Exception("Ponder mora biti decimalni broj veći od 0.");

            Dijagnoza dijagnoza = (Dijagnoza)frm.cbDijagnoze.SelectedItem;

            var list = GetStavkaList(frm.lbStavke);

            if (list.Any(s => s.Dijagnoza.Id == dijagnoza.Id))
                throw new Exception("Ta dijagnoza je već dodata.");

            StavkaZdravstvenogKartona stavka = new StavkaZdravstvenogKartona
            {
                ZdravstveniKarton = new ZdravstveniKarton
                {
                    Id = frm.ZdravstveniKarton?.Id ?? -1
                },
                DatumUpisa = DateTime.Now,
                Ponder = Convert.ToDouble(frm.tbPonder.Text.Trim()),
                Dijagnoza = dijagnoza,
            };

            list.Add(stavka);
            frm.lbStavke.DataSource = null;
            frm.lbStavke.DataSource = list;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Greška");
        }
    }

    internal void RemoveStavka()
    {
        try
        {
            FrmZdravstveniKartonCRUD frm = FormManager.Instance.Get<FrmZdravstveniKartonCRUD>();

            if (frm.lbStavke.SelectedItem == null)
                throw new Exception("Greška pri odabiru stavke zdravstvenog kartona.");

            StavkaZdravstvenogKartona stavka = (StavkaZdravstvenogKartona)frm.lbStavke.SelectedItem;

            var list = GetStavkaList(frm.lbStavke);
            list = list.Where(s => s.Dijagnoza.Id != stavka.Dijagnoza.Id).ToList();

            frm.lbStavke.DataSource = null;
            frm.lbStavke.DataSource = list;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Greška");
        }
    }

    protected override List<ZdravstveniKarton> BuildListResults(FrmZdravstveniKarton forma)
    {
        return new ZdravstveniKartonCriteriaBuilder()
            .WithDatumOtvaranjaAfter(forma.mcOtvorenNakon.SelectionStart)
            .WithImeLekara(forma.tbLekar.Text)
            .WithImePacijenta(forma.tbPacijent.Text)
            .WithDijagnoza((Dijagnoza)forma.cbDijagnoze.SelectedItem)
            .Build();
    }
}
