using Models.God;
using Models.Item;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business.God
{
    public class GodBusiness
    {
        string timespan;

        public GodBusiness(string timespan)
        {
            this.timespan = timespan;
        }

        public List<Models.God.GodCard>? GodList()
        {
            List<Models.God.God>? gods = new API.Api(timespan).GodList();
            return ConvertGodToGodCard(gods);
        }

        public List<Models.Item.ItemCard>? ItemList()
        {
            List<Models.Item.Item>? items = new API.Api(timespan).ItemList();
            return ConvertItemToItemCard(items);
        }

        public List<Models.Item.ItemCard>? ItemRecomendedList(int godID)
        {
            List<Models.Item.ItemCard>? items = ItemList();
            List<Models.Item.ItemRecomended>? recomendeds = new API.Api(timespan).ItemRecomendedList(godID);
            return ItemsRecomended(items, recomendeds);
        }

        #region PrivateMethods
        private List<Models.God.GodCard> ConvertGodToGodCard(List<Models.God.God>? gods)
        {
            List<Models.God.GodCard> godCardList = new List<Models.God.GodCard>();

            if (gods is null)
                throw new Exception("Lista de deuses nula.");

            foreach (Models.God.God god in gods)
            {
                Models.God.GodCard godCard = new Models.God.GodCard()
                {
                    ID = god.id,
                    Name = god.Name,
                    ImageUrl = god.godCard_URL,
                    Title = god.Title,
                    Pantheon = god.Pantheon,
                    Roles = god.Roles,
                };

                PantheonFill(godCard, god);
                RoleFill(godCard, god);
                LoreFill(godCard, god);
                AbilitiesFill(godCard, god);

                godCardList.Add(godCard);
            }

            return godCardList;
        }

        private List<Models.Item.ItemCard> ConvertItemToItemCard(List<Models.Item.Item>? items)
        {
            List<Models.Item.ItemCard> cards = new List<Models.Item.ItemCard>();
            foreach (Models.Item.Item item in items)
            {
                Models.Item.ItemCard card = new Models.Item.ItemCard()
                {
                    ItemID = item.ItemId,
                    ChildItemID = item.ChildItemId,
                    Name = item.DeviceName,
                    Url = item.itemIcon_URL,
                    Cost = item.Price,
                    Description = item?.ShortDesc,
                    DescriptionSecundary = item?.ItemDescription?.SecondaryDescription,
                    Tier = item?.ItemTier,
                };

                card.ItemCardDescriptions = new List<ItemCardDescription>();

                item?.ItemDescription?.Menuitems?.ForEach(obj =>
                {
                    ItemCardDescription itemCardDescription = new ItemCardDescription();
                    itemCardDescription.Value = obj.Value;
                    itemCardDescription.Description = obj.Description;

                    card.ItemCardDescriptions.Add(itemCardDescription);
                });

                cards.Add(card);
            }

            return cards;
        }

        private List<Models.Item.ItemCard> ItemsRecomended(List<Models.Item.ItemCard>? items, List<Models.Item.ItemRecomended>? recomendeds)
        {
            List<Models.Item.ItemCard> response = new List<ItemCard>();
            recomendeds.Where(obj => obj.Role == "Padrão").ToList().ForEach(obj =>
            {
                List<ItemCard> itemCard = items.Where(x => x.ItemID == obj.item_id).ToList();
                itemCard.ForEach(y =>
                {
                    response.Add(y);
                });
            });

            return response;
        }

        private void PantheonFill(Models.God.GodCard godCard, Models.God.God god)
        {
            switch (god.Pantheon)
            {
                case "Arthuriano":
                    godCard.PantheonUrl = "https://static.wikia.nocookie.net/smite_gamepedia/images/f/ff/NewUI_Pantheon_Arthurian.png/revision/latest?cb=20181222021929";
                    return;
                case "Babilônio":
                    godCard.PantheonUrl = "https://webcdn.hirezstudios.com/smite-media/wp-content/uploads/icon-babylonian-white-100x100.png";
                    return;
                case "Chinês":
                    godCard.PantheonUrl = "https://static.wikia.nocookie.net/smite_gamepedia/images/0/0e/NewUI_Pantheon_Chinese.png/revision/latest?cb=20150208141525";
                    return;
                case "Celta":
                    godCard.PantheonUrl = "https://static.wikia.nocookie.net/smite_gamepedia/images/a/a7/NewUI_Pantheon_Celtic.png/revision/latest?cb=20200528104818";
                    return;
                case "Egípcio":
                    godCard.PantheonUrl = "https://static.wikia.nocookie.net/smite_gamepedia/images/2/27/NewUI_Pantheon_Egyptian.png/revision/latest?cb=20150208141531";
                    return;
                case "Grego":
                    godCard.PantheonUrl = "https://static.wikia.nocookie.net/smite_gamepedia/images/7/7f/NewUI_Pantheon_Greek.png/revision/latest?cb=20150208141537";
                    return;
                case "Os Grandes Antigos":
                    godCard.PantheonUrl = "https://static.wikia.nocookie.net/smite_gamepedia/images/6/62/NewUI_Pantheon_Great_Old_Ones.png/revision/latest?cb=20200530225924";
                    return;
                case "Hindu":
                    godCard.PantheonUrl = "https://static.wikia.nocookie.net/smite_gamepedia/images/f/f8/NewUI_Pantheon_Hindu.png/revision/latest?cb=20150208141542";
                    return;
                case "Japonês":
                    godCard.PantheonUrl = "https://static.wikia.nocookie.net/smite_gamepedia/images/1/10/NewUI_Pantheon_Japanese.png/revision/latest?cb=20151127141517";
                    return;
                case "Maia":
                    godCard.PantheonUrl = "https://static.wikia.nocookie.net/smite_gamepedia/images/4/42/NewUI_Pantheon_Maya.png/revision/latest?cb=20150208141548";
                    return;
                case "Nórdico":
                    godCard.PantheonUrl = "https://static.wikia.nocookie.net/smite_gamepedia/images/2/2a/NewUI_Pantheon_Norse.png/revision/latest?cb=20150208141554";
                    return;
                case "Polinésio":
                    godCard.PantheonUrl = "https://static.wikia.nocookie.net/smite_gamepedia/images/3/37/NewUI_Pantheon_Polynesian.png/revision/latest?cb=20180923040248";
                    return;
                case "Romano":
                    godCard.PantheonUrl = "https://static.wikia.nocookie.net/smite_gamepedia/images/1/18/NewUI_Pantheon_Roman.png/revision/latest?cb=20150208141600";
                    return;
                case "Eslavo":
                    godCard.PantheonUrl = "https://static.wikia.nocookie.net/smite_gamepedia/images/1/1b/NewUI_Pantheon_Slavic.png/revision/latest?cb=20180530155605";
                    return;
                case "Vodu":
                    godCard.PantheonUrl = "https://static.wikia.nocookie.net/smite_gamepedia/images/c/c2/NewUI_Pantheon_Voodoo.png/revision/latest?cb=20180616064631";
                    return;
                case "Iorubá":
                    godCard.PantheonUrl = "https://static.wikia.nocookie.net/smite_gamepedia/images/4/49/NewUI_Pantheon_Yoruba.png/revision/latest?cb=20190627092514";
                    return;
                default:
                    godCard.PantheonUrl = "";
                    return;
            }
        }

        private void RoleFill(Models.God.GodCard godCard, Models.God.God god)
        {
            switch (god.Roles)
            {
                case "Guerreiro":
                    godCard.RolesUrl = "https://static.wikia.nocookie.net/smite_gamepedia/images/a/a0/NewUI_Class_Warrior.png/revision/latest?cb=20180923035656";
                    return;
                case "Guardião":
                    godCard.RolesUrl = "https://static.wikia.nocookie.net/smite_gamepedia/images/0/03/NewUI_Class_Guardian.png/revision/latest?cb=20180923035644";
                    return;
                case "Caçador":
                    godCard.RolesUrl = "https://static.wikia.nocookie.net/smite_gamepedia/images/a/a2/NewUI_Class_Hunter.png/revision/latest?cb=20180923035648";
                    return;
                case "Mago":
                    godCard.RolesUrl = "https://static.wikia.nocookie.net/smite_gamepedia/images/0/01/NewUI_Class_Mage.png/revision/latest?cb=20180923035652";
                    return;
                case "Assassino":
                    godCard.RolesUrl = "https://static.wikia.nocookie.net/smite_gamepedia/images/1/19/NewUI_Class_Assassin.png/revision/latest?cb=20180923035640";
                    return;
                default:
                    godCard.RolesUrl = "";
                    return;
            }
        }

        private void LoreFill(Models.God.GodCard godCard, Models.God.God god)
        {
            string[]? lores = god?.Lore?.Split("\\n\\n");
            if (lores != null)
            {
                StringBuilder sb = new StringBuilder();
                foreach (string l in lores)
                {
                    sb.AppendLine(l);
                }
                godCard.Lore = sb.ToString();
            }
        }

        private void AbilitiesFill(Models.God.GodCard godCard, Models.God.God god)
        {
            godCard.Abilities = new List<Ability>();

            List<AbilityDescription> descriptions = new List<AbilityDescription>();
            god.Ability_5?.Description?.itemDescription?.rankitems?.ForEach(obj =>
            {
                descriptions.Add(new AbilityDescription()
                {
                    Description = obj.description,
                    Value = obj.value,
                });
            });
            godCard.Abilities.Add(new Ability()
            {
                Summary = god.Ability_5?.Summary,
                URL = god.Ability_5?.URL,
                Description = god.Ability_5?.Description?.itemDescription?.description,
                Cooldown = god.Ability_5?.Description?.itemDescription?.cooldown,
                Cost = god.Ability_5?.Description?.itemDescription?.cost,
                AbilityDescriptions = descriptions,
            });
            descriptions = new List<AbilityDescription>();
            god.Ability_1?.Description?.itemDescription?.rankitems?.ForEach(obj =>
            {
                descriptions.Add(new AbilityDescription()
                {
                    Description = obj.description,
                    Value = obj.value,
                });
            });
            godCard.Abilities.Add(new Ability()
            {
                Summary = god.Ability_1?.Summary,
                URL = god.Ability_1?.URL,
                Description = god.Ability_1?.Description?.itemDescription?.description,
                Cooldown = god.Ability_1?.Description?.itemDescription?.cooldown,
                Cost = god.Ability_1?.Description?.itemDescription?.cost,
                AbilityDescriptions = descriptions,
            });
            descriptions = new List<AbilityDescription>();
            god.Ability_2?.Description?.itemDescription?.rankitems?.ForEach(obj =>
            {
                descriptions.Add(new AbilityDescription()
                {
                    Description = obj.description,
                    Value = obj.value,
                });
            });
            godCard.Abilities.Add(new Ability()
            {
                Summary = god.Ability_2?.Summary,
                URL = god.Ability_2?.URL,
                Description = god.Ability_2?.Description?.itemDescription?.description,
                Cooldown = god.Ability_2?.Description?.itemDescription?.cooldown,
                Cost = god.Ability_2?.Description?.itemDescription?.cost,
                AbilityDescriptions = descriptions,
            });

            descriptions = new List<AbilityDescription>();
            god.Ability_3?.Description?.itemDescription?.rankitems?.ForEach(obj =>
            {
                descriptions.Add(new AbilityDescription()
                {
                    Description = obj.description,
                    Value = obj.value,
                });
            });
            godCard.Abilities.Add(new Ability()
            {
                Summary = god.Ability_3?.Summary,
                URL = god.Ability_3?.URL,
                Description = god.Ability_3?.Description?.itemDescription?.description,
                Cooldown = god.Ability_3?.Description?.itemDescription?.cooldown,
                Cost = god.Ability_3?.Description?.itemDescription?.cost,
                AbilityDescriptions = descriptions,
            });

            descriptions = new List<AbilityDescription>();
            god.Ability_4?.Description?.itemDescription?.rankitems?.ForEach(obj =>
            {
                descriptions.Add(new AbilityDescription()
                {
                    Description = obj.description,
                    Value = obj.value,
                });
            });
            godCard.Abilities.Add(new Ability()
            {
                Summary = god.Ability_4?.Summary,
                URL = god.Ability_4?.URL,
                Description = god.Ability_4?.Description?.itemDescription?.description,
                Cooldown = god.Ability_4?.Description?.itemDescription?.cooldown,
                Cost = god.Ability_4?.Description?.itemDescription?.cost,
                AbilityDescriptions = descriptions,
            });
        }
        #endregion PrivateMethods
    }
}
