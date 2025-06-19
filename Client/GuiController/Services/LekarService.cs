using Client.Forms;
using Client.GuiController.Criteria;
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
        protected override Operation RetreiveAllListOperation => Operation.VratiListuSviLekar;
        protected override FrmLekar GetForm() => FormManager.Instance.Get<FrmLekar>() ?? new FrmLekar();
        protected override FrmLekarCRUD GetCrudForm() => FormManager.Instance.Get<FrmLekarCRUD>() ?? FormManager.Instance.Open<FrmLekarCRUD>(form => form.FormClosed += (s, e) => FetchListAll(), true);
        protected override void CloseCrudForm() => FormManager.Instance.Close<FrmLekarCRUD>();

        protected override Lekar CreateEntityFromForm(FrmLekarCRUD form) => new Lekar
        {
            Id = form.Lekar?.Id ?? 0,
            Ime = form.tbIme.Text.Trim(),
            Prezime = form.tbPrezime.Text.Trim(),
            Email = form.tbEmail.Text.Trim(),
            KorisnickoIme = form.tbKorisnickoIme.Text.Trim(),
            Sifra = form.tbSifra.Text.Trim(),
            Sertifikati = form.lbSertifikati.Items.Cast<Sertifikat>().ToList()
        };

        protected override void FillFormWithEntity(FrmLekarCRUD form, Lekar entity)
        {
            form.ShowDetails(entity);
        }

        protected override void BindSearchResults(FrmLekar form, List<Lekar> results)
        {
            form.dgvLekari.DataSource = results;

            foreach (DataGridViewColumn col in form.dgvLekari.Columns)
            {
                col.Visible = col.Name == nameof(Lekar.Id)
                           || col.Name == nameof(Lekar.Ime)
                           || col.Name == nameof(Lekar.Prezime)
                           || col.Name == nameof(Lekar.Email)
                           || col.Name == nameof(Lekar.Sertifikati);
            }
        }

        internal void Login()
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
                    KorisnickoIme = frm.tbKorisnickoIme.Text.Trim(),
                    Sifra = frm.tbSifra.Text.Trim(),
                };

                Response response = Communication.Instance.SendRequestGetObject<Lekar, Lekar>(lekar, Operation.PrijaviLekar);

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

                Session.Instance.CurrentLekar = response.Result as Lekar;
                MessageBox.Show("Korisničko ime i šifra su ispravni.");

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

        protected override void ValidateBeforeOperation(Lekar entity)
        {
            if (Session.Instance.CurrentLekar != null && Session.Instance.CurrentLekar.Id == entity.Id)
                return;

            throw new UnauthorizedAccessException("Ne možete izvesti ovu operaciju nad drugim lekarom.");
        }

        internal void AddSertifikat()
        {
            try
            {
                FrmLekarCRUD frm = FormManager.Instance.Get<FrmLekarCRUD>();

                if (frm.cbSertifikati.SelectedItem == null || frm.cbSertifikati.SelectedIndex == 0)
                    throw new Exception("Greška pri odabiru sertifikata.");

                Sertifikat newSertifikat = (Sertifikat)frm.cbSertifikati.SelectedItem;

                var list = GetSertifikatList(frm.lbSertifikati);

                if (list.Any(s => s.Id == newSertifikat.Id))
                    throw new Exception("Taj sertifikat je već dodat.");

                list.Add(newSertifikat);
                frm.lbSertifikati.DataSource = null;
                frm.lbSertifikati.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška");
            }
        }

        internal void RemoveSertifikat()
        {
            try
            {
                FrmLekarCRUD frm = FormManager.Instance.Get<FrmLekarCRUD>();

                if (frm.lbSertifikati.SelectedItem == null)
                    throw new Exception("Greška pri odabiru sertifikata.");

                Sertifikat selected = (Sertifikat)frm.lbSertifikati.SelectedItem;

                var list = GetSertifikatList(frm.lbSertifikati);
                list = list.Where(s => s.Id != selected.Id).ToList();

                frm.lbSertifikati.DataSource = null;
                frm.lbSertifikati.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška");
            }
        }

        private List<Sertifikat> GetSertifikatList(ListBox lb)
        {
            return lb.DataSource as List<Sertifikat> ?? lb.Items.OfType<Sertifikat>().ToList();
        }

        protected override List<Lekar> BuildListResults(FrmLekar form)
        {
            return new LekarCriteriaBuilder()
                .WithIme(form.tbIme.Text)
                .WithPrezime(form.tbPrezime.Text)
                .WithSertifikat((Sertifikat)form.cbSertifikati.SelectedItem)
                .Build();
        }
    }
}
