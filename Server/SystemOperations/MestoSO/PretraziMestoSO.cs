using Common.Domain;

namespace Server.SystemOperations.MestoSO
{
    internal class PretraziMestoSO : SystemOperationBase
    {
        private readonly string kriterijumi;
        internal List<Mesto> Result { get; private set; }

        internal PretraziMestoSO(string kriterijumi)
        {
            this.kriterijumi = kriterijumi;
        }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.GetByCondition(new Mesto(), kriterijumi);
            Result = lista.OfType<Mesto>().ToList();
        }
    }
}
