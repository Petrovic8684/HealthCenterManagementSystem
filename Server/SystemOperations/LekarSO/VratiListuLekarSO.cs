using Common.Domain;
using DBBroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations.LekarSO
{
    internal class VratiListuLekarSO : SystemOperationBase
    {
        private readonly IEntity criteria;
        private List<Lekar> list;
        internal List<Lekar> Result { get; private set; }

        internal VratiListuLekarSO(IEntity criteria, List<Lekar> list)
        {
            this.criteria = criteria;
            this.list = list;
            Result = new List<Lekar>();
        }

        protected override void ExecuteConcreteOperation()
        {
            Lekar criteriaLekar;

            if (criteria is Lekar lekar)
                criteriaLekar = lekar;
            
            else if (criteria is Sertifikat sertifikat)
            {
                criteriaLekar = new();
                criteriaLekar.Sertifikati = new List<Sertifikat> { sertifikat };
            }
            
            else throw new ArgumentException("Kriterijum mora biti tipa Lekar ili Sertifikat.");

            list = broker.GetByCondition(criteriaLekar).Cast<Lekar>().ToList();
            Result = list;
        }
    }
}
