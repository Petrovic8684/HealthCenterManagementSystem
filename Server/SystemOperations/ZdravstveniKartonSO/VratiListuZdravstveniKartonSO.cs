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
        private readonly IEntity criteria;
        private List<ZdravstveniKarton> list;
        internal List<ZdravstveniKarton> Result { get; private set; }

        internal VratiListuZdravstveniKartonSO(IEntity criteria, List<ZdravstveniKarton> list)
        {
            this.criteria = criteria;
            this.list = list;
            Result = new List<ZdravstveniKarton>();
        }

        protected override void ExecuteConcreteOperation()
        {
            ZdravstveniKarton criterionZdravstveniKarton;

            switch (criteria)
            {
                case ZdravstveniKarton karton:
                    criterionZdravstveniKarton = karton;
                    break;

                case Pacijent pacijent:
                    MessageBox.Show(pacijent.Ime);
                    criterionZdravstveniKarton = new ZdravstveniKarton
                    {
                        Pacijent = pacijent
                    };
                    break;

                case Lekar lekar:
                    criterionZdravstveniKarton = new ZdravstveniKarton
                    {
                        Lekar = lekar
                    };
                    break;

                case Dijagnoza dijagnoza:
                    criterionZdravstveniKarton = new ZdravstveniKarton
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

            list = broker.GetByCondition(criterionZdravstveniKarton).Cast<ZdravstveniKarton>().ToList();
            Result = list;
        }
    }
}
