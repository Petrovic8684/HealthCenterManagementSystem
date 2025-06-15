using DBBroker;

namespace Server.SystemOperations
{
    internal abstract class SystemOperationBase
    {
        protected Broker broker;

        internal SystemOperationBase()
        {
            broker = new Broker(ConfigManager.DBConnectionString);
        }

        internal void ExecuteTemplate()
        {
            try
            {
                broker.OpenConnection();
                broker.BeginTransaction();

                ExecuteConcreteOperation();

                broker.Commit();
            }
            catch (Exception ex)
            {
                broker.Rollback();
                throw;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        protected abstract void ExecuteConcreteOperation();
    }
}
