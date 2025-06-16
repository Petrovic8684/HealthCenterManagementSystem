using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations.PacijentSO
{
    internal class VratiListuPacijentSO : SystemOperationBase
    {
        private readonly IEntity kriterijumi;
        private List<Pacijent> list;
        internal List<Pacijent> Result { get; private set; }

        internal VratiListuPacijentSO(IEntity kriterijumi, List<Pacijent> list)
        {
            this.kriterijumi = kriterijumi;
            this.list = list;
            Result = new List<Pacijent>();
        }

        protected override void ExecuteConcreteOperation()
        {
            Pacijent kriterijumPacijent;

            if (kriterijumi is Pacijent p)
                kriterijumPacijent = p;
            
            else if (kriterijumi is Mesto m)
                kriterijumPacijent = new Pacijent { Mesto = m };

            else throw new ArgumentException("Kriterijum mora biti tipa Pacijent ili Mesto.");

            list = broker.GetByCondition(kriterijumPacijent).Cast<Pacijent>().ToList();
            Result = list;
        }
    }
}
