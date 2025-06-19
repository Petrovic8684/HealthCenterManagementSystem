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
        private readonly IEntity criteria;
        private List<Pacijent> list;
        internal List<Pacijent> Result { get; private set; }

        internal VratiListuPacijentSO(IEntity criteria, List<Pacijent> list)
        {
            this.criteria = criteria;
            this.list = list;
            Result = new List<Pacijent>();
        }

        protected override void ExecuteConcreteOperation()
        {
            Pacijent criterionPacijent;

            if (criteria is Pacijent pacijent)
                criterionPacijent = pacijent;
            
            else if (criteria is Mesto mesto)
                criterionPacijent = new Pacijent { Mesto = mesto };

            else throw new ArgumentException("Kriterijum mora biti tipa Pacijent ili Mesto.");

            list = broker.GetByCondition(criterionPacijent).Cast<Pacijent>().ToList();
            Result = list;
        }
    }
}
