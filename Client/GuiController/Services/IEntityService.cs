namespace Client.GuiController.Services
{
    internal interface IEntityService<T> where T : class, IEntity
    {
        void Kreiraj();
        List<T> Pretrazi();
        void PrikaziDetalje();
        void Promeni();
        void Obrisi();
    }
}
