using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        const string SulfurasName = "Sulfuras, Hand of Ragnaros";

        IList<Item> Items;
        private ItemUpdateService svcUpdateQuality;

        public GildedRose(IList<Item> Items)
        {
            svcUpdateQuality = new ItemUpdateService();
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                UpdateItem(item);
            }
        }

        private void UpdateItem(Item item)
        {
            UpdateItemSellin(item);
            UpdateItemQuality(item);
        }

        private void UpdateItemSellin(Item item)
        {
            bool IsSulfuras = item.Name == SulfurasName;
            if (IsSulfuras)
            {
                return;
            }
            else
            {
                DecreaseSellin(item);
            }
        }

        private void UpdateItemQuality(Item item)
        {
            var updateService = svcUpdateQuality.GetItemUpdateService(item.Name);
            if (updateService != null)
            {
                updateService.UpdateQuality(item);
                return;
            }
        }

        private void DecreaseSellin(Item item)
        {
            item.SellIn -= 1;
        }
    }
}
