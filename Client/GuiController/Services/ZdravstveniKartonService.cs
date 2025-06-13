using Common.Communication;
using Common.Domain;

namespace Client.GuiController.Services
{
    internal class ZdravstveniKartonService : IEntityService<ZdravstveniKarton>
    {
        public void Kreiraj()
        {
            try
            {
                FrmZdravstveniKartonCRUD frm = FormManager.Instance.Get<FrmZdravstveniKartonCRUD>();

                if (!frm.Validation())
                    throw new Exception("Sva polja moraju biti popunjena.");

                ZdravstveniKarton zdravstveniKarton = new ZdravstveniKarton
                {
                    Lekar = (Lekar)frm.cbLekari.SelectedItem,
                    Pacijent = (Pacijent)frm.cbPacijenti.SelectedItem,
                    Napomena = frm.tbNapomena.Text.Trim(),
                    DatumOtvaranja = DateTime.Now,

                    Stavke = frm.lbStavke.Items.Cast<StavkaZdravstvenogKartona>().ToList()
                };

                Response response = Communication.Instance.SendRequest<ZdravstveniKarton, ZdravstveniKarton>(zdravstveniKarton, Operation.KreirajZdravstveniKarton);

                if (response.ExceptionType != null)
                    throw new Exception(response.ExceptionMessage);

                MessageBox.Show("Sistem je zapamtio zdravstveni karton.");
                FormManager.Instance.Close<FrmZdravstveniKartonCRUD>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da zapamti zdravstveni karton.\n\n(" + ex.Message + ")", "Greška");
            }
        }

        public List<ZdravstveniKarton> Pretrazi()
        {
            try
            {
                FrmZdravstveniKarton? frm = FormManager.Instance.Get<FrmZdravstveniKarton>();

                if (frm == null) frm = new();
                string kriterijum = frm.ConstructCriteria();

                Response response = Communication.Instance.SendRequestList<string, ZdravstveniKarton>(kriterijum, Operation.PretraziZdravstveniKarton);

                if (response.ExceptionType != null)
                    throw new Exception(response.ExceptionMessage);

                MessageBox.Show("Sistem je našao zdravstvene kartone po zadatim kriterijumima.");
                frm.dgvZdravstveniKartoni.DataSource = response.Result;

                foreach (DataGridViewColumn col in frm.dgvZdravstveniKartoni.Columns)
                    if (col.Name != nameof(ZdravstveniKarton.Id) && col.Name != nameof(ZdravstveniKarton.DatumOtvaranja) && col.Name != nameof(ZdravstveniKarton.Napomena) &&
                        col.Name != nameof(ZdravstveniKarton.UkupniSkor) && col.Name != nameof(ZdravstveniKarton.Stanje) && col.Name != nameof(ZdravstveniKarton.Lekar) && col.Name != nameof(ZdravstveniKarton.Pacijent))
                        col.Visible = false;

                return response.Result as List<ZdravstveniKarton>;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da pronađe zdravstvene kartone.\n\n(" + ex.Message + ")", "Greška");
                return null;
            }
        }

        public void PrikaziDetalje()
        {
            try
            {
                FrmZdravstveniKarton frm = FormManager.Instance.Get<FrmZdravstveniKarton>();

                if (frm.dgvZdravstveniKartoni.SelectedRows.Count == 0)
                    throw new Exception("Nijedan zdravstveni karton nije selektovan.");

                ZdravstveniKarton selektovani = frm.dgvZdravstveniKartoni.SelectedRows[0].DataBoundItem as ZdravstveniKarton;

                if (selektovani == null)
                    throw new Exception();

                FormManager.Instance.Open<FrmZdravstveniKartonCRUD>(f =>
                {
                    f.PrikaziDetalje(selektovani);
                    f.FormClosed += (s, e) => Pretrazi();
                });

                MessageBox.Show("Sistem je našao zdravstveni karton.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da nađe zdravstveni karton.\n\n(" + ex.Message + ")", "Greška");
            }
        }

        public void Promeni()
        {
            try
            {
                FrmZdravstveniKartonCRUD frm = FormManager.Instance.Get<FrmZdravstveniKartonCRUD>();

                if (!frm.Validation())
                    throw new Exception("Sva polja moraju biti popunjena.");

                ZdravstveniKarton zdravstveniKarton = new ZdravstveniKarton
                {
                    Id = frm.ZdravstveniKarton.Id,
                    Lekar = (Lekar)frm.cbLekari.SelectedItem,
                    Pacijent = (Pacijent)frm.cbPacijenti.SelectedItem,
                    Napomena = frm.tbNapomena.Text.Trim(),
                    DatumOtvaranja = frm.ZdravstveniKarton.DatumOtvaranja,

                    Stavke = frm.lbStavke.Items.Cast<StavkaZdravstvenogKartona>().ToList()
                };

                Response response = Communication.Instance.SendRequest<ZdravstveniKarton, ZdravstveniKarton>(zdravstveniKarton, Operation.PromeniZdravstveniKarton);

                if (response.ExceptionType != null)
                    throw new Exception(response.ExceptionMessage);

                MessageBox.Show("Sistem je uspešno izmenio zdravstveni karton.");
                FormManager.Instance.Close<FrmZdravstveniKartonCRUD>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da izmeni zdravstveni karton.\n\n(" + ex.Message + ")", "Greška");
            }
        }

        public void Obrisi() { }

        private List<StavkaZdravstvenogKartona> GetStavkeList(ListBox lb)
        {
            return lb.DataSource as List<StavkaZdravstvenogKartona> ?? lb.Items.OfType<StavkaZdravstvenogKartona>().ToList();
        }

        internal void DodajStavku()
        {
            try
            {
                FrmZdravstveniKartonCRUD frm = FormManager.Instance.Get<FrmZdravstveniKartonCRUD>();

                if (frm.cbDijagnoze.SelectedItem == null || frm.cbDijagnoze.SelectedIndex == 0)
                    throw new Exception("Greška pri odabiru dijagnoze.");

                Dijagnoza dijagnoza = (Dijagnoza)frm.cbDijagnoze.SelectedItem;

                var lista = GetStavkeList(frm.lbStavke);

                if (lista.Any(s => s.Dijagnoza.Id == dijagnoza.Id))
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

                lista.Add(stavka);
                frm.lbStavke.DataSource = null;
                frm.lbStavke.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška");
            }
        }

        internal void OduzmiStavku()
        {
            try
            {
                FrmZdravstveniKartonCRUD frm = FormManager.Instance.Get<FrmZdravstveniKartonCRUD>();

                if (frm.lbStavke.SelectedItem == null)
                    throw new Exception("Greška pri odabiru stavke zdravstvenog kartona.");

                StavkaZdravstvenogKartona stavka = (StavkaZdravstvenogKartona)frm.lbStavke.SelectedItem;

                var lista = GetStavkeList(frm.lbStavke);
                lista = lista.Where(s => s.Dijagnoza.Id != stavka.Dijagnoza.Id).ToList();

                frm.lbStavke.DataSource = null;
                frm.lbStavke.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška");
            }
        }
    }
}
