using Common.Domain;

namespace Server.SystemOperations.PacijentSO
{
    internal class PretraziPacijentSO : SystemOperationBase
    {
        private readonly string kriterijumi;
        internal List<Pacijent> Result { get; private set; }

        internal PretraziPacijentSO(string kriterijumi)
        {
            this.kriterijumi = kriterijumi;
        }

        protected override void ExecuteConcreteOperation()
        {
            List<Pacijent> lista = broker.GetByCondition(new Pacijent(), kriterijumi).OfType<Pacijent>().ToList();

            foreach (Pacijent pacijent in lista)
            {
                Mesto mesto = (Mesto)broker.GetByCondition(new Mesto(), $"idMesto = {pacijent.Mesto.Id}")[0];
                pacijent.Mesto = mesto;
            }

            Result = lista;
        }
    }
}
