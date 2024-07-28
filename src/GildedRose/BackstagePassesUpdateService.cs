using System;

namespace GildedRoseKata;

public class BackstagePassesUpdateService : IQualityUpdateService
{
    public void UpdateQuality(Item item)
    {
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
