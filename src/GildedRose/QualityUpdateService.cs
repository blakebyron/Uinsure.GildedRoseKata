using System;

namespace GildedRoseKata;

public class UpdateQualityService
{
    const string AgedBrieName = "Aged Brie";
    const string BackstagepassesName = "Backstage passes to a TAFKAL80ETC concert";
    public IQualityUpdateService GetQualityUpdateService(string name)
    {
        switch (name)
        {
            case AgedBrieName:
                return new AgedBrieUpdateService();
            case BackstagepassesName:
                return new BackstagePassesUpdateService();
            default:
                return null;
        }
    }
}