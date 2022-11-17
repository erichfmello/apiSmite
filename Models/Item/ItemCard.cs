namespace Models.Item
{
    public class ItemCard
    {
        public int ItemID { get; set; }
        public int ChildItemID { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public int Cost { get; set; }
        public string? Description { get; set; }
        public string? DescriptionSecundary { get; set; }
        public int? Tier { get; set; }
        public List<ItemCardDescription>? ItemCardDescriptions { get; set; }
    }

    public class ItemCardDescription
    {
        public string? Description { get; set; }
        public string? Value { get; set; }
    }
}
