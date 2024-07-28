using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        const string BackstagepassesName = "Backstage passes to a TAFKAL80ETC concert";
        const string SulfurasName = "Sulfuras, Hand of Ragnaros";

        IList<Item> Items;
        private UpdateQualityService svcUpdateQuality;

        public GildedRose(IList<Item> Items)
        {
            svcUpdateQuality = new UpdateQualityService();
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
            var updateService = svcUpdateQuality.GetQualityUpdateService(item.Name);
            if (updateService != null)
            {
                updateService.UpdateQuality(item);
                return;
            }
            switch (item.Name)
            {
                case SulfurasName:
                    break;
                default:
                    DecreaseQuality(item);
                    if (item.SellIn < 0)
                    {
                        DecreaseQuality(item);
                    }
                    break;
            }
        }

        private void DecreaseQuality(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality -= 1;
            }
        }

        private void DecreaseSellin(Item item)
        {
            item.SellIn -= 1;
        }
    }
}
