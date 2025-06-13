using Common.Communication;
using Common.Domain;

namespace Client.GuiController.Services
{
    internal class LekarService : BaseEntityService<Lekar, FrmLekar, FrmLekarCRUD>
    {
        protected override Operation CreateOperation => Operation.KreirajLekar;
        protected override Operation UpdateOperation => Operation.PromeniLekar;
        protected override Operation DeleteOperation => Operation.ObrisiLekar;
        protected override Operation SearchOperation => Operation.PretraziLekar;

        protected override FrmLekar GetSearchForm() => FormManager.Instance.Get<FrmLekar>() ?? new FrmLekar();

        protected override FrmLekarCRUD GetCrudForm() => FormManager.Instance.Get<FrmLekarCRUD>();

        protected override Lekar CreateEntityFromForm(FrmLekarCRUD form) => new Lekar
        {
            Id = form.Lekar?.Id ?? 0,
            Ime = form.tbIme.Text.Trim(),
            Prezime = form.tbPrezime.Text.Trim(),
            Email = form.tbEmail.Text.Trim(),
            Sifra = form.tbSifra.Text.Trim(),
            Sertifikati = form.lbSertifikati.Items.Cast<Sertifikat>().ToList()
        };

        protected override void FillFormWithEntity(FrmLekarCRUD form, Lekar entity)
        {
            form.PrikaziDetalje(entity);
        }

        protected override string GetSearchCriteria(FrmLekar form) => form.ConstructCriteria();

        protected override void BindSearchResults(FrmLekar form, List<Lekar> results)
        {
            form.dgvLekari.DataSource = results;

            foreach (DataGridViewColumn col in form.dgvLekari.Columns)
            {
                col.Visible = col.Name == nameof(Lekar.Id)
                           || col.Name == nameof(Lekar.Ime)
                           || col.Name == nameof(Lekar.Prezime)
                           || col.Name == nameof(Lekar.Email)
                           || col.Name == nameof(Lekar.Sifra)
                           || col.Name == nameof(Lekar.Sertifikati);
            }
        }

        internal void Prijavi()
        {
            try
            {
                FrmLogin frm = FormManager.Instance.Get<FrmLogin>();

                if (!frm.Validation())
                {
                    MessageBox.Show("Molimo popunite sva polja.");
                    return;
                }

                Lekar lekar = new Lekar
                {
                    Email = frm.tbEmail.Text,
                    Sifra = frm.tbSifra.Text,
                };

                Response response = Communication.Instance.SendRequest<Lekar, Lekar>(lekar, Operation.PrijaviLekar);

                if (response.ExceptionType != null)
                {
                    switch (response.ExceptionType)
                    {
                        case "System.UnauthorizedAccessException":
                            throw new UnauthorizedAccessException();
                        default:
                            throw new Exception(response.ExceptionMessage);
                    }
                }

                Session.CurrentLekar = response.Result as Lekar;

                FormManager.Instance.Open<FrmMenu>();
                FormManager.Instance.Close<FrmLogin>();
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Korisničko ime i šifra nisu ispravni.", "Greška");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ne može da se otvori glavna forma i meni.\n\n(" + ex.Message + ")", "Greška");
            }
        }

        internal void DodajSertifikat()
        {
            try
            {
                FrmLekarCRUD frm = FormManager.Instance.Get<FrmLekarCRUD>();

                if (frm.cbSertifikati.SelectedItem == null || frm.cbSertifikati.SelectedIndex == 0)
                    throw new Exception("Greška pri odabiru sertifikata.");

                Sertifikat novi = (Sertifikat)frm.cbSertifikati.SelectedItem;

                var lista = GetSertifikatiList(frm.lbSertifikati);

                if (lista.Any(s => s.Id == novi.Id))
                    throw new Exception("Taj sertifikat je već dodat.");

                lista.Add(novi);
                frm.lbSertifikati.DataSource = null;
                frm.lbSertifikati.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška");
            }
        }

        internal void OduzmiSertifikat()
        {
            try
            {
                FrmLekarCRUD frm = FormManager.Instance.Get<FrmLekarCRUD>();

                if (frm.lbSertifikati.SelectedItem == null)
                    throw new Exception("Greška pri odabiru sertifikata.");

                Sertifikat izabrani = (Sertifikat)frm.lbSertifikati.SelectedItem;

                var lista = GetSertifikatiList(frm.lbSertifikati);
                lista = lista.Where(s => s.Id != izabrani.Id).ToList();

                frm.lbSertifikati.DataSource = null;
                frm.lbSertifikati.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška");
            }
        }

        private List<Sertifikat> GetSertifikatiList(ListBox lb)
        {
            return lb.DataSource as List<Sertifikat> ?? lb.Items.OfType<Sertifikat>().ToList();
        }
    }
}
