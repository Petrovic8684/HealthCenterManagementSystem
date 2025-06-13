using Common.Communication;
using Common.Domain;

namespace Client.GuiController.Services
{
    internal class DijagnozaService : IEntityService<Dijagnoza>
    {
        public void Kreiraj()
        {
            try
            {
                FrmDijagnozaCRUD frm = FormManager.Instance.Get<FrmDijagnozaCRUD>();

                if (!frm.Validation())
                    throw new Exception("Nisu popunjena sva obavezna polja.");

                Dijagnoza dijagnoza = new Dijagnoza
                {
                    Naziv = frm.tbNaziv.Text.Trim(),
                    Opis = frm.tbOpis.Text.Trim(),
                    BazniSkor = Convert.ToDouble(frm.tbBazniSkor.Text.Trim()),
                };

                Response response = Communication.Instance.SendRequest<Dijagnoza, Dijagnoza>(dijagnoza, Operation.KreirajDijagnoza);

                if (response.ExceptionType != null)
                    throw new Exception(response.ExceptionMessage);

                MessageBox.Show("Sistem je zapamtio dijagnozu.");
                FormManager.Instance.Close<FrmDijagnozaCRUD>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da zapamti dijagnozu.\n\n(" + ex.Message + ")", "Greška");
            }
        }

        public List<Dijagnoza> Pretrazi()
        {
            try
            {
                FrmDijagnoza? frm = FormManager.Instance.Get<FrmDijagnoza>();

                if (frm == null) frm = new();
                string kriterijumi = frm.ConstructCriteria();

                Response response = Communication.Instance.SendRequestList<string, Dijagnoza>(kriterijumi, Operation.PretraziDijagnoza);

                if (response.ExceptionType != null)
                    throw new Exception(response.ExceptionMessage);

                MessageBox.Show("Sistem je našao dijagnoze po zadatim kriterijumima.");

                frm.dgvDijagnoze.DataSource = response.Result;

                foreach (DataGridViewColumn column in frm.dgvDijagnoze.Columns)
                    if (column.Name != nameof(Dijagnoza.Id) && column.Name != nameof(Dijagnoza.Naziv) && column.Name != nameof(Dijagnoza.Opis) && column.Name != nameof(Dijagnoza.BazniSkor))
                        column.Visible = false;

                return response.Result as List<Dijagnoza>;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da nađe dijagnoze po zadatim kriterijumima.\n\n(" + ex.Message + ")", "Greška");
                return null;
            }
        }

        public void Promeni()
        {
            try
            {
                FrmDijagnozaCRUD frm = FormManager.Instance.Get<FrmDijagnozaCRUD>();

                if (!frm.Validation())
                    throw new Exception("Nisu popunjena sva obavezna polja.");

                Dijagnoza dijagnoza= new Dijagnoza
                {
                    Id = frm.Dijagnoza.Id,
                    Naziv = frm.tbNaziv.Text.Trim(),
                    Opis = frm.tbOpis.Text.Trim(),
                    BazniSkor = Convert.ToDouble(frm.tbBazniSkor.Text.Trim()),
                };

                Response response = Communication.Instance.SendRequest<Dijagnoza, Dijagnoza>(dijagnoza, Operation.PromeniDijagnoza);

                if (response.ExceptionType != null)
                    throw new Exception(response.ExceptionMessage);

                MessageBox.Show("Sistem je uspešno izmenio dijagnozu.");
                FormManager.Instance.Close<FrmDijagnozaCRUD>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da izmeni dijagnozu.\n\n(" + ex.Message + ")", "Greška");
            }
        }

        public void Obrisi()
        {
            try
            {
                FrmDijagnozaCRUD frm = FormManager.Instance.Get<FrmDijagnozaCRUD>();

                Dijagnoza dijagnoza = new Dijagnoza
                {
                    Id = frm.Dijagnoza.Id
                };

                Response response = Communication.Instance.SendRequest<Dijagnoza, Dijagnoza>(dijagnoza, Operation.ObrisiDijagnoza);

                if (response.ExceptionType != null)
                    throw new Exception(response.ExceptionMessage);

                MessageBox.Show("Dijagnoza je uspešno obrisana.");
                FormManager.Instance.Close<FrmDijagnozaCRUD>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da obriše dijagnozu.\n\n(" + ex.Message + ")", "Greška");
            }
        }

        public void PrikaziDetalje()
        {
            try
            {
                FrmDijagnoza frm = FormManager.Instance.Get<FrmDijagnoza>();

                if (frm.dgvDijagnoze.SelectedRows.Count == 0)
                    throw new Exception("Nije izabran nijedan red u tabeli.");

                Dijagnoza selektovana = frm.dgvDijagnoze.SelectedRows[0].DataBoundItem as Dijagnoza;

                if (selektovana == null)
                    throw new Exception();

                MessageBox.Show("Sistem je našao dijagnozu.");

                FormManager.Instance.Open<FrmDijagnozaCRUD>(f =>
                {
                    f.PrikaziDetalje(selektovana);
                    f.FormClosed += (s, e) => Pretrazi();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da nađe dijagnozu.\n\n(" + ex.Message + ")", "Greška");
            }
        }
    }
}
