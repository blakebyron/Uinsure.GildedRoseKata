using System;

namespace GildedRoseKata;

public class ConjuredManaCakeUpdateService : IItemUpdateService
{
    public void UpdateQuality(Item item)
    {
        DecreaseQuality(item);
        if (item.SellIn < 0)
        {
            DecreaseQuality(item);
        }
    }

    private void DecreaseQuality(Item item)
    {
        if (item.Quality > 0)
        {
            item.Quality -= 2;
        }
    }

    public void UpdateSellin(Item item)
    {
        DecreaseSellin(item);
    }

    private void DecreaseSellin(Item item)
    {
        item.SellIn -= 1;
    }
}
