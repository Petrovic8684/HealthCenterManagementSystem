using Client.GuiController;
using Common.Domain;

namespace Client
{
    internal class Session
    {
        private static Session instance;
        internal static Session Instance => instance ??= new Session();

        private Session() { }

        internal Lekar CurrentLekar { get; set; }

        internal void Clear()
        {
            CurrentLekar = null;
        }
    }
}
