namespace Models.God
{
    public class GodCard
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public string? Title { get; set; }
        public string? Pantheon { get; set; }
        public string? PantheonUrl { get; set; }
        public string? Roles { get; set; }
        public string? RolesUrl { get; set; }
        public string? Lore { get; set; }
        public List<Ability>? Abilities { get; set; }
    }

    public class Ability
    {
        public string? Summary { get; set; }
        public string? URL { get; set; }
        public string? Description { get; set; }
        public string? Cooldown { get; set; }
        public string? Cost { get; set; }
        public List<AbilityDescription>? AbilityDescriptions { get; set; }
    }

    public class AbilityDescription
    {
        public string? Description { get; set; }
        public string? Value { get; set; }
    }
}
