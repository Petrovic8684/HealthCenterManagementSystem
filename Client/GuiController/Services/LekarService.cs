using Common.Communication;
using Common.Domain;

namespace Client.GuiController.Services
{
    internal class LekarService : IEntityService<Lekar>
    {
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

        public void Kreiraj()
        {
            try
            {
                FrmLekarCRUD frm = FormManager.Instance.Get<FrmLekarCRUD>();

                if (!frm.Validation())
                    throw new Exception("Sva polja moraju biti popunjena.");

                Lekar lekar = new Lekar
                {
                    Ime = frm.tbIme.Text.Trim(),
                    Prezime = frm.tbPrezime.Text.Trim(),
                    Email = frm.tbEmail.Text.Trim(),
                    Sifra = frm.tbSifra.Text.Trim(),

                    Sertifikati = frm.lbSertifikati.Items.Cast<Sertifikat>().ToList()
                };

                Response response = Communication.Instance.SendRequest<Lekar, Lekar>(lekar, Operation.KreirajLekar);

                if (response.ExceptionType != null)
                    throw new Exception(response.ExceptionMessage);

                MessageBox.Show("Sistem je zapamtio lekara.");
                FormManager.Instance.Close<FrmLekarCRUD>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da zapamti lekara.\n\n(" + ex.Message + ")", "Greška");
            }
        }

        public List<Lekar> Pretrazi()
        {
            try
            {
                FrmLekar? frm = FormManager.Instance.Get<FrmLekar>();

                if (frm == null) frm = new();
                string kriterijum = frm.ConstructCriteria();

                Response response = Communication.Instance.SendRequestList<string, Lekar>(kriterijum, Operation.PretraziLekar);

                if (response.ExceptionType != null)
                    throw new Exception(response.ExceptionMessage);

                MessageBox.Show("Sistem je našao lekare po zadatim kriterijumima.");
                frm.dgvLekari.DataSource = response.Result;

                foreach (DataGridViewColumn col in frm.dgvLekari.Columns)
                    if (col.Name != nameof(Lekar.Id) && col.Name != nameof(Lekar.Ime) && col.Name != nameof(Lekar.Prezime) && col.Name != nameof(Lekar.Email) && col.Name != nameof(Lekar.Sifra) && col.Name != nameof(Lekar.Sertifikati))
                        col.Visible = false;

                return response.Result as List<Lekar>;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da pronađe lekare.\n\n(" + ex.Message + ")", "Greška");
                return null;
            }
        }

        public void PrikaziDetalje()
        {
            try
            {
                FrmLekar frm = FormManager.Instance.Get<FrmLekar>();

                if (frm.dgvLekari.SelectedRows.Count == 0)
                    throw new Exception("Nijedan lekar nije selektovan.");

                Lekar selektovani = frm.dgvLekari.SelectedRows[0].DataBoundItem as Lekar;

                if (selektovani == null)
                    throw new Exception();

                MessageBox.Show("Sistem je našao lekara.");

                FormManager.Instance.Open<FrmLekarCRUD>(f =>
                {
                    f.PrikaziDetalje(selektovani);
                    f.FormClosed += (s, e) => Pretrazi();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da nađe lekara.\n\n(" + ex.Message + ")", "Greška");
            }
        }

        public void Promeni()
        {
            try
            {
                FrmLekarCRUD frm = FormManager.Instance.Get<FrmLekarCRUD>();

                if (!frm.Validation())
                    throw new Exception("Sva polja moraju biti popunjena.");

                Lekar lekar = new Lekar
                {
                    Id = frm.Lekar.Id,
                    Ime = frm.tbIme.Text.Trim(),
                    Prezime = frm.tbPrezime.Text.Trim(),
                    Email = frm.tbEmail.Text.Trim(),
                    Sifra = frm.tbSifra.Text.Trim(),

                    Sertifikati = frm.lbSertifikati.Items.Cast<Sertifikat>().ToList()
                };

                Response response = Communication.Instance.SendRequest<Lekar, Lekar>(lekar, Operation.PromeniLekar);

                if (response.ExceptionType != null)
                    throw new Exception(response.ExceptionMessage);

                MessageBox.Show("Sistem je uspešno izmenio lekara.");
                FormManager.Instance.Close<FrmLekarCRUD>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da izmeni lekara.\n\n(" + ex.Message + ")", "Greška");
            }
        }

        public void Obrisi()
        {
            try
            {
                FrmLekarCRUD frm = FormManager.Instance.Get<FrmLekarCRUD>();

                Lekar lekar = new Lekar
                {
                    Id = frm.Lekar.Id
                };

                Response response = Communication.Instance.SendRequest<Lekar, Lekar>(lekar, Operation.ObrisiLekar);

                if (response.ExceptionType != null)
                    throw new Exception(response.ExceptionMessage);

                MessageBox.Show("Lekar je uspešno obrisan.");
                FormManager.Instance.Close<FrmLekarCRUD>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da obriše lekara.\n\n(" + ex.Message + ")", "Greška");
            }
        }

        private List<Sertifikat> GetSertifikatiList(ListBox lb)
        {
            return lb.DataSource as List<Sertifikat> ?? lb.Items.OfType<Sertifikat>().ToList();
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

    }
}
