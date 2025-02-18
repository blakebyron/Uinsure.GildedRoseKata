﻿using System;

namespace GildedRoseKata;

public class ItemUpdateService
{
    const string AgedBrieName = "Aged Brie";
    const string BackstagepassesName = "Backstage passes to a TAFKAL80ETC concert";
    const string DexterityVestName = "+5 Dexterity Vest";
    const string ElixiroftheMongoose = "Elixir of the Mongoose";
    const string ConjuredManaCake = "Conjured Mana Cake";


    public IItemUpdateService GetItemUpdateService(string name)
    {
        switch (name)
        {
            case AgedBrieName:
                return new AgedBrieUpdateService();
            case BackstagepassesName:
                return new BackstagePassesUpdateService();
            case DexterityVestName:
                return new DexterityVestUpdateService();
            case ElixiroftheMongoose:
                return new ElixieoftheMongooseUpdateService();
            case ConjuredManaCake:
                return new ConjuredManaCakeUpdateService();
            default:
                return null;
        }
    }
}