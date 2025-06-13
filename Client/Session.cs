using Common.Domain;

namespace Client
{
    internal static class Session
    {
        internal static Lekar CurrentLekar { get; set; }

        internal static void Clear()
        {
            CurrentLekar = null;
        }
    }
}
