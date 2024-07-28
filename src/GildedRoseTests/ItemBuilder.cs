using System;
using GildedRoseKata;

namespace GildedRoseTests;

public class ItemBuilder
{
    private readonly Item Item;

    public ItemBuilder()
    {
        Item = new Item();
    }

    public static ItemBuilder Create() => new ItemBuilder();

    public ItemBuilder WithName(string name)
    {
        Item.Name = name;
        return this;
    }

    public ItemBuilder WithQuality(int quality)
    {
        Item.Quality = quality;
        return this;
    }

    public ItemBuilder WithSellIn(int sellin)
    {
        Item.SellIn = sellin;
        return this;
    }
    public Item Build() => Item;
}
