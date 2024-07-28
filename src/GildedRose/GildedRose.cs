using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        const string AgedBrieName = "Aged Brie";
        const string BackstagepassesName = "Backstage passes to a TAFKAL80ETC concert";
        const string SulfurasName = "Sulfuras, Hand of Ragnaros";

        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
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
            switch (item.Name)
            {
                case SulfurasName:
                    break;

                case AgedBrieName:
                    IncreaseQuality(item);
                    if (item.SellIn < 0)
                    {
                        IncreaseQuality(item);
                    }
                    break;
                case BackstagepassesName:
                    IncreaseQuality(item);

                    if (item.SellIn < 10)
                    {
                        IncreaseQuality(item);
                    }

                    if (item.SellIn < 5)
                    {
                        IncreaseQuality(item);
                    }
                    if (item.SellIn < 0)
                    {
                        MakeQualityZero(item);
                    }
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

        private void IncreaseQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;
            }
        }

        private void MakeQualityZero(Item item)
        {
            item.Quality = 0;
        }

        private void DecreaseSellin(Item item)
        {
            item.SellIn -= 1;
        }
    }
}
