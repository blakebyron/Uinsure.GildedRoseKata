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
            bool IsAgedBrie = item.Name == "Aged Brie";
            bool IsBackstagepasses = item.Name == "Backstage passes to a TAFKAL80ETC concert";
            bool IsSulfuras = item.Name == "Sulfuras, Hand of Ragnaros";

            if (IsAgedBrie)
            {
                IncreaseQuality(item);
            }
            else if (IsBackstagepasses)
            {
                IncreaseQuality(item);

                if (item.SellIn < 11)
                {
                    IncreaseQuality(item);
                }

                if (item.SellIn < 6)
                {
                    IncreaseQuality(item);
                }

            }
            else
            {
                if (IsSulfuras)
                {
                }
                else
                {
                    DecreaseQuality(item);
                }
            }

            if (IsSulfuras)
            {
            }
            else
            {
                item.SellIn = item.SellIn - 1;
            }

            if (item.SellIn < 0)
            {
                if (IsAgedBrie)
                {
                    IncreaseQuality(item);
                }
                else if (IsBackstagepasses)
                {
                    MakeQualityZero(item);
                }
                else
                {
                    if (IsSulfuras)
                    {
                        return;
                    }
                    DecreaseQuality(item);
                }
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
    }
}
