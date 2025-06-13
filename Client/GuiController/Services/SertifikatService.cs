using Common.Communication;
using Common.Domain;

namespace Client.GuiController.Services
{
    internal class SertifikatService : IEntityService<Sertifikat>
    {
        public void Kreiraj()
        {
            try
            {
                FrmSertifikatCRUD frm = FormManager.Instance.Get<FrmSertifikatCRUD>();

                if (!frm.Validation())
                    throw new Exception("Nije popunjeno polje za opis sertifikata.");

                Sertifikat sertifikat = new Sertifikat
                {
                    Opis = frm.tbOpis.Text.Trim(),
                };

                Response response = Communication.Instance.SendRequest<Sertifikat, Sertifikat>(sertifikat, Operation.UbaciSertifikat);

                if (response.ExceptionType != null)
                    throw new Exception(response.ExceptionMessage);

                MessageBox.Show("Sistem je zapamtio sertifikat.");
                FormManager.Instance.Close<FrmSertifikatCRUD>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da zapamti sertifikat.\n\n(" + ex.Message + ")", "Greška");
            }
        }

        public List<Sertifikat> Pretrazi()
        {
            try
            {
                FrmSertifikat? frm = FormManager.Instance.Get<FrmSertifikat>();

                if (frm == null) frm = new();
                string kriterijumi = frm.ConstructCriteria();

                Response response = Communication.Instance.SendRequestList<string, Sertifikat>(kriterijumi, Operation.PretraziSertifikat);

                if (response.ExceptionType != null)
                    throw new Exception(response.ExceptionMessage);

                MessageBox.Show("Sistem je našao sertifikate po zadatim kriterijumima.");

                frm.dgvSertifikati.DataSource = response.Result;

                foreach (DataGridViewColumn column in frm.dgvSertifikati.Columns)
                    if (column.Name != nameof(Sertifikat.Id) && column.Name != nameof(Sertifikat.Opis))
                        column.Visible = false;

                return response.Result as List<Sertifikat>;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da nađe sertifikate po zadatim kriterijumima.\n\n(" + ex.Message + ")", "Greška");
                return null;
            }
        }

        public void Promeni()
        {
            try
            {
                FrmSertifikatCRUD frm = FormManager.Instance.Get<FrmSertifikatCRUD>();

                if (!frm.Validation())
                    throw new Exception("Nije popunjeno polje za opis sertifikata.");

                Sertifikat sertifikat = new Sertifikat
                {
                    Id = frm.Sertifikat.Id,
                    Opis = frm.tbOpis.Text.Trim()
                };

                Response response = Communication.Instance.SendRequest<Sertifikat, Sertifikat>(sertifikat, Operation.PromeniSertifikat);

                if (response.ExceptionType != null)
                    throw new Exception(response.ExceptionMessage);

                MessageBox.Show("Sistem je uspešno izmenio sertifikat.");
                FormManager.Instance.Close<FrmSertifikatCRUD>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da izmeni sertifikat.\n\n(" + ex.Message + ")", "Greška");
            }
        }

        public void Obrisi()
        {
            try
            {
                FrmSertifikatCRUD frm = FormManager.Instance.Get<FrmSertifikatCRUD>();

                Sertifikat sertifikat = new Sertifikat
                {
                    Id = frm.Sertifikat.Id
                };

                Response response = Communication.Instance.SendRequest<Sertifikat, Sertifikat>(sertifikat, Operation.ObrisiSertifikat);

                if (response.ExceptionType != null)
                    throw new Exception(response.ExceptionMessage);

                MessageBox.Show("Sertifikat je uspešno obrisan.");
                FormManager.Instance.Close<FrmSertifikatCRUD>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da obriše sertifikat.\n\n(" + ex.Message + ")", "Greška");
            }
        }

        public void PrikaziDetalje()
        {
            try
            {
                FrmSertifikat frm = FormManager.Instance.Get<FrmSertifikat>();

                if (frm.dgvSertifikati.SelectedRows.Count == 0)
                    throw new Exception("Nije izabran nijedan red u tabeli.");

                Sertifikat selektovani = frm.dgvSertifikati.SelectedRows[0].DataBoundItem as Sertifikat;

                if (selektovani == null)
                    throw new Exception();

                MessageBox.Show("Sistem je našao sertifikat.");

                FormManager.Instance.Open<FrmSertifikatCRUD>(f =>
                {
                    f.PrikaziDetalje(selektovani);
                    f.FormClosed += (s, e) => Pretrazi();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da nađe sertifikat.\n\n(" + ex.Message + ")", "Greška");
            }
        }
    }
}
