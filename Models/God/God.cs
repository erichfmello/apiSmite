namespace Models.God
{
    public class God
    {
        public int AbilityId1 { get; set; }
        public string? Ability1 { get; set; }
        public int AbilityId2 { get; set; }
        public string? Ability2 { get; set; }
        public int AbilityId3 { get; set; }
        public string? Ability3 { get; set; }
        public int AbilityId4 { get; set; }
        public string? Ability4 { get; set; }
        public int AbilityId5 { get; set; }
        public string? Ability5 { get; set; }

        public GodAbility? Ability_1 { get; set; }
        public GodAbility? Ability_2 { get; set; }
        public GodAbility? Ability_3 { get; set; }
        public GodAbility? Ability_4 { get; set; }
        public GodAbility? Ability_5 { get; set; }

        public decimal AttackSpeed { get; set; }
        public decimal AttackSpeedPerLevel { get; set; }
        public string? AutoBanned { get; set; }
        public string? Cons { get; set; }
        public decimal HP5PerLevel { get; set; }
        public int Health { get; set; }
        public int HealthPerFive { get; set; }
        public int HealthPerLevel { get; set; }
        public string? Lore { get; set; }
        public decimal MP5PerLevel { get; set; }
        public decimal MagicProtection { get; set; }
        public decimal MagicProtectionPerLevel { get; set; }
        public int MagicalPower { get; set; }
        public decimal MagicalPowerPerLevel { get; set; }
        public int Mana { get; set; }
        public decimal ManaPerFive { get; set; }
        public int ManaPerLevel { get; set; }
        public string? Name { get; set; }
        public string? OnFreeRotation { get; set; }
        public string? Pantheon { get; set; }
        public int PhysicalPower { get; set; }
        public decimal PhysicalPowerPerLevel { get; set; }
        public decimal PhysicalProtection { get; set; }
        public decimal PhysicalProtectionPerLevel { get; set; }
        public string? Pros { get; set; }
        public string? Roles { get; set; }
        public int Speed { get; set; }
        public string? Title { get; set; }
        public string? Type { get; set; }

        public GodAbility? basicAttack { get; set; }

        public string? godAbility1_URL { get; set; }
        public string? godAbility2_URL { get; set; }
        public string? godAbility3_URL { get; set; }
        public string? godAbility4_URL { get; set; }
        public string? godAbility5_URL { get; set; }
        public string? godCard_URL { get; set; }
        public string? godIcon_URL { get; set; }
        public int id { get; set; }
        public string? latestGod { get; set; }
        public string? ret_msg { get; set; }
    }
}