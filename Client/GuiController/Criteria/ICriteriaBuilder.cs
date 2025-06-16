namespace Client.GuiController.Criteria
{
    internal interface ICriteriaBuilder<T> where T : ICrudEntity, new()
    {
        List<T> Build();
    }
}
