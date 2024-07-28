using System;

namespace GildedRoseKata;

public class UpdateQualityService
{
    const string AgedBrieName = "Aged Brie";

    public IQualityUpdateService GetQualityUpdateService(string name)
    {
        switch (name)
        {
            case AgedBrieName:
                return new AgedBrieUpdateService();
            default:
                return null;
        }
    }
}