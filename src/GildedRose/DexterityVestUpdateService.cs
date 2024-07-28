using System;

namespace GildedRoseKata;

public class DexterityVestUpdateService : IItemUpdateService
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
            item.Quality -= 1;
        }
    }
}
