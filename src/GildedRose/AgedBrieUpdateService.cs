using System;

namespace GildedRoseKata;

public class AgedBrieUpdateService : IQualityUpdateService
{
    public void UpdateQuality(Item item)
    {
        IncreaseQuality(item);
        if (item.SellIn < 0)
        {
            IncreaseQuality(item);
        }
    }

    private void IncreaseQuality(Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality += 1;
        }
    }
}
