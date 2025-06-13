namespace Client.GuiController.Criteria
{
    internal interface ICriteriaBuilder<T> where T : ICrudEntity, new()
    {
        T Build();
    }
}
