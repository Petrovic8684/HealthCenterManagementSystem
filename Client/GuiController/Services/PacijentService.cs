using Common.Communication;
using Common.Domain;

namespace Client.GuiController.Services
{
    internal class PacijentService : IEntityService<Pacijent>
    {
        public void Kreiraj()
        {
            try
            {
                FrmPacijentCRUD frm = FormManager.Instance.Get<FrmPacijentCRUD>();

                if (!frm.Validation())
                    throw new Exception("Sva polja moraju biti popunjena.");

                Pacijent pacijent = new Pacijent
                {
                    Ime = frm.tbIme.Text.Trim(),
                    Prezime = frm.tbPrezime.Text.Trim(),
                    Email = frm.tbEmail.Text.Trim(),

                    Mesto = (Mesto)frm.cbMesta.SelectedItem
                };

                Response response = Communication.Instance.SendRequest<Pacijent, Pacijent>(pacijent, Operation.KreirajPacijent);

                if (response.ExceptionType != null)
                    throw new Exception(response.ExceptionMessage);

                MessageBox.Show("Sistem je zapamtio pacijenta.");
                FormManager.Instance.Close<FrmPacijentCRUD>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da zapamti pacijenta.\n\n(" + ex.Message + ")", "Greška");
            }
        }

        public List<Pacijent> Pretrazi()
        {
            try
            {
                FrmPacijent? frm = FormManager.Instance.Get<FrmPacijent>();

                if (frm == null) frm = new();
                string kriterijum = frm.ConstructCriteria();

                Response response = Communication.Instance.SendRequestList<string, Pacijent>(kriterijum, Operation.PretraziPacijent);

                if (response.ExceptionType != null)
                    throw new Exception(response.ExceptionMessage);

                MessageBox.Show("Sistem je našao pacijente po zadatim kriterijumima.");
                frm.dgvPacijenti.DataSource = response.Result;

                foreach (DataGridViewColumn col in frm.dgvPacijenti.Columns)
                    if (col.Name != nameof(Pacijent.Id) && col.Name != nameof(Pacijent.Ime) && col.Name != nameof(Pacijent.Prezime) && col.Name != nameof(Pacijent.Email) && col.Name != nameof(Pacijent.Mesto))
                        col.Visible = false;

                return response.Result as List<Pacijent>;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da pronađe pacijente.\n\n(" + ex.Message + ")", "Greška");
                return null;
            }
        }

        public void PrikaziDetalje()
        {
            try
            {
                FrmPacijent frm = FormManager.Instance.Get<FrmPacijent>();

                if (frm.dgvPacijenti.SelectedRows.Count == 0)
                    throw new Exception("Nijedan pacijent nije selektovan.");

                Pacijent selektovani = frm.dgvPacijenti.SelectedRows[0].DataBoundItem as Pacijent;

                if (selektovani == null)
                    throw new Exception();

                MessageBox.Show("Sistem je našao pacijenta.");

                FormManager.Instance.Open<FrmPacijentCRUD>(f =>
                {
                    f.PrikaziDetalje(selektovani);
                    f.FormClosed += (s, e) => Pretrazi();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da nađe pacijenta.\n\n(" + ex.Message + ")", "Greška");
            }
        }

        public void Promeni()
        {
            try
            {
                FrmPacijentCRUD frm = FormManager.Instance.Get<FrmPacijentCRUD>();

                if (!frm.Validation())
                    throw new Exception("Sva polja moraju biti popunjena.");

                Pacijent pacijent = new Pacijent
                {
                    Id = frm.Pacijent.Id,
                    Ime = frm.tbIme.Text.Trim(),
                    Prezime = frm.tbPrezime.Text.Trim(),
                    Email = frm.tbEmail.Text.Trim(),

                    Mesto = (Mesto)frm.cbMesta.SelectedItem
                };

                Response response = Communication.Instance.SendRequest<Pacijent, Pacijent>(pacijent, Operation.PromeniPacijent);

                if (response.ExceptionType != null)
                    throw new Exception(response.ExceptionMessage);

                MessageBox.Show("Sistem je uspešno izmenio pacijenta.");
                FormManager.Instance.Close<FrmPacijentCRUD>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da izmeni pacijenta.\n\n(" + ex.Message + ")", "Greška");
            }
        }

        public void Obrisi()
        {
            try
            {
                FrmPacijentCRUD frm = FormManager.Instance.Get<FrmPacijentCRUD>();

                Pacijent pacijent = new Pacijent
                {
                    Id = frm.Pacijent.Id,
                    Mesto = new Mesto { Id = - 1 }
                };

                Response response = Communication.Instance.SendRequest<Pacijent, Pacijent>(pacijent, Operation.ObrisiPacijent);

                if (response.ExceptionType != null)
                    throw new Exception(response.ExceptionMessage);

                MessageBox.Show("Pacijent je uspešno obrisan.");
                FormManager.Instance.Close<FrmPacijentCRUD>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da obriše pacijenta.\n\n(" + ex.Message + ")", "Greška");
            }
        }
    }
}
