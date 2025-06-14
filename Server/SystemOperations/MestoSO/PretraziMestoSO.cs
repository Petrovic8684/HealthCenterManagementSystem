using Common.Domain;

namespace Server.SystemOperations.MestoSO
{
    internal class PretraziMestoSO : SystemOperationBase
    {
        private readonly Mesto kriterijumi;
        internal List<Mesto> Result { get; private set; }

        internal PretraziMestoSO(Mesto kriterijumi)
        {
            this.kriterijumi = kriterijumi;
        }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.GetByCondition(kriterijumi);
            Result = lista.OfType<Mesto>().ToList();
        }
    }
}
