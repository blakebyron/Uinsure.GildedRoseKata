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
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }
            }
            else if (IsBackstagepasses)
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;

                    if (item.SellIn < 11)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality = item.Quality + 1;
                        }
                    }

                    if (item.SellIn < 6)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality = item.Quality + 1;
                        }
                    }
                }
            }
            else
            {
                if (item.Quality > 0)
                {
                    if (IsSulfuras)
                    {
                    }
                    else
                    {
                        item.Quality = item.Quality - 1;
                    }
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
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
                else
                {
                    if (IsBackstagepasses)
                    {
                        item.Quality = item.Quality - item.Quality;
                    }
                    else
                    {
                        if (item.Quality > 0)
                        {
                            if (IsSulfuras)
                            {
                                return;
                            }
                            item.Quality = item.Quality - 1;
                        }
                    }
                }
            }
        }
    }
}
