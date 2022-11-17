namespace WebApi.ViewModel.Item
{
    public class ItemListRequest : BaseRequest
    {
    }

    public class ItemListResponse : BaseListResponse<Models.Item.ItemCard>
    {
    }

    public class ItemRecomendedListRequest : BaseRequest
    {
        public int GodID { get; set; }
    }

    public class ItemRecomendedListResponse : BaseListResponse<Models.Item.ItemCard>
    {
    }
}
