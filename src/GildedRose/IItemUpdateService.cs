using System;

namespace GildedRoseKata;

public interface IItemUpdateService
{
    void UpdateQuality(Item item);
    void UpdateSellin(Item item);
}
