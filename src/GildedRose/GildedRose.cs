using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                Update(Items[i]);
            }
        }

        private void Update(Item item)
        {
            const string AgedBrieName = "Aged Brie";
            const string BackstagepassesName = "Backstage passes to a TAFKAL80ETC concert";
            const string SulfurasName = "Sulfuras, Hand of Ragnaros";

            bool IsSulfuras = item.Name == SulfurasName;

            switch (item.Name)
            {
                case SulfurasName:
                    break;

                case AgedBrieName:
                    IncreaseQuality(item);
                    break;
                case BackstagepassesName:
                    IncreaseQuality(item);

                    if (item.SellIn < 11)
                    {
                        IncreaseQuality(item);
                    }

                    if (item.SellIn < 6)
                    {
                        IncreaseQuality(item);
                    }
                    break;

                default:
                    DecreaseQuality(item);
                    break;
            }

            if (IsSulfuras)
            {
            }
            else
            {
                DecreaseSellin(item);
            }

            switch (item.Name)
            {
                case SulfurasName:
                    break;

                case AgedBrieName:
                    if (item.SellIn < 0)
                    {
                        IncreaseQuality(item);
                    }
                    break;
                case BackstagepassesName:
                    if (item.SellIn < 0)
                    {
                        MakeQualityZero(item);
                    }
                    break;

                default:
                    if (item.SellIn < 0)
                    {
                        DecreaseQuality(item);
                    }
                    break;
            }
        }

        private static void DecreaseQuality(Item item)
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
