using Common.Domain;
using DBBroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations.ZdravstveniKartonSO
{
    internal class VratiListuZdravstveniKartonSO : SystemOperationBase
    {
        private readonly IEntity kriterijumi;
        private List<ZdravstveniKarton> list;
        internal List<ZdravstveniKarton> Result { get; private set; }

        internal VratiListuZdravstveniKartonSO(IEntity kriterijumi, List<ZdravstveniKarton> list)
        {
            this.kriterijumi = kriterijumi;
            this.list = list;
            Result = new List<ZdravstveniKarton>();
        }

        protected override void ExecuteConcreteOperation()
        {
            ZdravstveniKarton kriterijumKarton;

            switch (kriterijumi)
            {
                case ZdravstveniKarton karton:
                    kriterijumKarton = karton;
                    break;

                case Pacijent pacijent:
                    MessageBox.Show(pacijent.Ime);
                    kriterijumKarton = new ZdravstveniKarton
                    {
                        Pacijent = pacijent
                    };
                    break;

                case Lekar lekar:
                    kriterijumKarton = new ZdravstveniKarton
                    {
                        Lekar = lekar
                    };
                    break;

                case Dijagnoza dijagnoza:
                    kriterijumKarton = new ZdravstveniKarton
                    {
                        Stavke = new List<StavkaZdravstvenogKartona>
                        {
                            new StavkaZdravstvenogKartona
                            {
                                Dijagnoza = dijagnoza
                            }
                        }
                    };
                    break;

                default:
                    throw new ArgumentException("Kriterijum mora biti tipa ZdravstveniKarton, Pacijent, Lekar ili Dijagnoza.");
            }

            list = broker.GetByCondition(kriterijumKarton).Cast<ZdravstveniKarton>().ToList();
            Result = list;
        }
    }
}
