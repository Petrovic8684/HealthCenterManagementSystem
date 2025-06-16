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
        private readonly IEntity kriterijumi;
        private List<Lekar> list;
        internal List<Lekar> Result { get; private set; }

        internal VratiListuLekarSO(IEntity kriterijumi, List<Lekar> list)
        {
            this.kriterijumi = kriterijumi;
            this.list = list;
            Result = new List<Lekar>();
        }

        protected override void ExecuteConcreteOperation()
        {
            Lekar kriterijumLekar;

            if (kriterijumi is Lekar lekar)
                kriterijumLekar = lekar;
            
            else if (kriterijumi is Sertifikat sertifikat)
            {
                kriterijumLekar = new();
                kriterijumLekar.Sertifikati = new List<Sertifikat> { sertifikat };
            }
            
            else throw new ArgumentException("Kriterijum mora biti tipa Lekar ili Sertifikat.");

            list = broker.GetByCondition(kriterijumLekar).Cast<Lekar>().ToList();
            Result = list;
        }
    }
}
