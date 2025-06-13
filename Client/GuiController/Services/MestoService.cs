using Common.Communication;
using Common.Domain;

namespace Client.GuiController.Services
{
    internal class MestoService : IEntityService<Mesto>
    {
        public void Kreiraj()
        {
            try
            {
                FrmMestoCRUD frm = FormManager.Instance.Get<FrmMestoCRUD>();

                if (!frm.Validation())
                    throw new Exception("Nisu popunjena sva obavezna polja.");

                Mesto mesto = new Mesto
                {
                    Naziv = frm.tbNaziv.Text.Trim(),
                    PostanskiBroj = frm.tbPostanskiBroj.Text.Trim(),
                };

                Response response = Communication.Instance.SendRequest<Mesto, Mesto>(mesto, Operation.KreirajMesto);

                if (response.ExceptionType != null)
                    throw new Exception(response.ExceptionMessage);

                MessageBox.Show("Sistem je zapamtio mesto.");
                FormManager.Instance.Close<FrmMestoCRUD>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da zapamti mesto.\n\n(" + ex.Message + ")", "Greška");
            }
        }

        public List<Mesto> Pretrazi()
        {
            try
            {
                FrmMesto? frm = FormManager.Instance.Get<FrmMesto>();

                if (frm == null) frm = new();
                string kriterijumi = frm.ConstructCriteria();

                Response response = Communication.Instance.SendRequestList<string, Mesto>(kriterijumi, Operation.PretraziMesto);

                if (response.ExceptionType != null)
                    throw new Exception(response.ExceptionMessage);

                MessageBox.Show("Sistem je našao mesta po zadatim kriterijumima.");

                frm.dgvMesta.DataSource = response.Result;

                foreach (DataGridViewColumn column in frm.dgvMesta.Columns)
                    if (column.Name != nameof(Mesto.Id) && column.Name != nameof(Mesto.Naziv) && column.Name != nameof(Mesto.PostanskiBroj))
                        column.Visible = false;

                return response.Result as List<Mesto>;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da nađe mesta po zadatim kriterijumima.\n\n(" + ex.Message + ")", "Greška");
                return null;
            }
        }

        public void Promeni()
        {
            try
            {
                FrmMestoCRUD frm = FormManager.Instance.Get<FrmMestoCRUD>();

                if (!frm.Validation())
                    throw new Exception("Nisu popunjena sva obavezna polja.");

                Mesto mesto = new Mesto
                {
                    Id = frm.Mesto.Id,
                    Naziv = frm.tbNaziv.Text.Trim(),
                    PostanskiBroj = frm.tbPostanskiBroj.Text.Trim(),
                };

                Response response = Communication.Instance.SendRequest<Mesto, Mesto>(mesto, Operation.PromeniMesto);

                if (response.ExceptionType != null)
                    throw new Exception(response.ExceptionMessage);

                MessageBox.Show("Sistem je uspešno izmenio mesto.");
                FormManager.Instance.Close<FrmMestoCRUD>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da izmeni mesto.\n\n(" + ex.Message + ")", "Greška");
            }
        }

        public void Obrisi()
        {
            try
            {
                FrmMestoCRUD frm = FormManager.Instance.Get<FrmMestoCRUD>();

                Mesto mesto= new Mesto
                {
                    Id = frm.Mesto.Id
                };

                Response response = Communication.Instance.SendRequest<Mesto, Mesto>(mesto, Operation.ObrisiMesto);

                if (response.ExceptionType != null)
                    throw new Exception(response.ExceptionMessage);

                MessageBox.Show("Mesto je uspešno obrisano.");
                FormManager.Instance.Close<FrmMestoCRUD>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da obriše mesto.\n\n(" + ex.Message + ")", "Greška");
            }
        }

        public void PrikaziDetalje()
        {
            try
            {
                FrmMesto frm = FormManager.Instance.Get<FrmMesto>();

                if (frm.dgvMesta.SelectedRows.Count == 0)
                    throw new Exception("Nije izabran nijedan red u tabeli.");

                Mesto selektovano = frm.dgvMesta.SelectedRows[0].DataBoundItem as Mesto;

                if (selektovano == null)
                    throw new Exception();

                MessageBox.Show("Sistem je našao mesto.");

                FormManager.Instance.Open<FrmMestoCRUD>(f =>
                {
                    f.PrikaziDetalje(selektovano);
                    f.FormClosed += (s, e) => Pretrazi();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da nađe mesto.\n\n(" + ex.Message + ")", "Greška");
            }
        }
    }
}
