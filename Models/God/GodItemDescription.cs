namespace Models.God
{
    public class GodItemDescription
    {
        public string? cooldown { get; set; }
        public string? cost { get; set; }
        public string? description { get; set; }
        public List<GodItems>? menuitems { get; set; }
        public List<GodItems>? rankitems { get; set; }
    }
}
