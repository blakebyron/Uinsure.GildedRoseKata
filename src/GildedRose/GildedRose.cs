﻿using System.Collections.Generic;

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
            if (item.Name == "Aged Brie" || item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;

                    if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
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
            }
            else
            {
                if (item.Quality > 0)
                {
                    if (item.Name == "Sulfuras, Hand of Ragnaros")
                    {
                    }
                    else
                    {
                        item.Quality = item.Quality - 1;
                    }
                }
            }

            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
            }
            else
            {
                item.SellIn = item.SellIn - 1;
            }

            if (item.SellIn < 0)
            {
                if (item.Name == "Aged Brie")
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
                else
                {
                    if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        item.Quality = item.Quality - item.Quality;
                    }
                    else
                    {
                        if (item.Quality > 0)
                        {
                            if (item.Name != "Sulfuras, Hand of Ragnaros")
                            {
                                item.Quality = item.Quality - 1;
                            }
                        }
                    }
                }
            }
        }
    }
}
