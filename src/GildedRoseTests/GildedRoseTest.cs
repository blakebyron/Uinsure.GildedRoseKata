using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Theory]
        [InlineData(ItemNames.DexterityVest, 10, 9)]
        [InlineData(ItemNames.DexterityVest, 5, 4)]
        [InlineData(ItemNames.ElixiroftheMongoose, 15, 14)]
        [InlineData(ItemNames.ElixiroftheMongoose, 3, 2)]
        public void DegradeQualityByOneAtEndOfDay(string name, int quality, int expectedQuality)
        {
            //Arrange
            IList<Item> Items = new List<Item> { CreateAnItem(name, quality, 10) };
            GildedRose sut = new GildedRose(Items);

            //Act
            sut.UpdateQuality();

            //Assert
            Assert.Equal(expectedQuality, Items[0].Quality);
        }

        [Theory]
        [InlineData(ItemNames.DexterityVest, 10, 9)]
        [InlineData(ItemNames.DexterityVest, 5, 4)]
        [InlineData(ItemNames.ElixiroftheMongoose, 15, 14)]
        [InlineData(ItemNames.ElixiroftheMongoose, 3, 2)]
        public void ReduceSellInByOneAtEndOfDay(string name, int sellin, int expectedSellin)
        {
            //Arrange
            IList<Item> Items = new List<Item> { CreateAnItem(name, 10, sellin) };
            GildedRose sut = new GildedRose(Items);

            //Act
            sut.UpdateQuality();

            //Assert
            Assert.Equal(expectedSellin, Items[0].SellIn);
        }
        [Theory]
        [InlineData(ItemNames.DexterityVest, 10, 8)]
        [InlineData(ItemNames.DexterityVest, 5, 3)]
        [InlineData(ItemNames.ElixiroftheMongoose, 15, 13)]
        [InlineData(ItemNames.ElixiroftheMongoose, 3, 1)]
        public void DegradeQualityTwiceAsFastAfterSellByAtEndOfDay(string name, int quality, int expectedQuality)
        {
            //Arrange
            IList<Item> Items = new List<Item> { CreateAnItem(name, quality, 0) };
            GildedRose sut = new GildedRose(Items);

            //Act
            sut.UpdateQuality();

            //Assert
            Assert.Equal(expectedQuality, Items[0].Quality);
        }

        [Theory]
        [InlineData(ItemNames.DexterityVest, 0)]
        [InlineData(ItemNames.ElixiroftheMongoose, 0)]
        public void QualityCanNeverBeLowerThanZero(string name, int quality)
        {
            //Arrange
            IList<Item> Items = new List<Item> { CreateAnItem(name, quality, 1) };
            GildedRose sut = new GildedRose(Items);

            //Act
            sut.UpdateQuality();

            //Assert
            Assert.Equal(0, Items[0].Quality);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(10, 11)]
        public void AgedBrieIncreasesInQualityByOneAtEndofDay(int quality, int expectedQuality)
        {
            //Arrange
            IList<Item> Items = new List<Item> { CreateAnItem(ItemNames.AgedBrie, quality, 1) };
            GildedRose sut = new GildedRose(Items);

            //Act
            sut.UpdateQuality();

            //Assert
            Assert.Equal(expectedQuality, Items[0].Quality);
        }

        [Theory]
        [InlineData(ItemNames.AgedBrie, 50)]
        [InlineData(ItemNames.Backstagepasses, 50)]
        public void QualityCanNeverBeGreaterThan50(string name, int quality)
        {
            //Arrange
            IList<Item> Items = new List<Item> { CreateAnItem(name, quality, 1) };
            GildedRose sut = new GildedRose(Items);

            //Act
            sut.UpdateQuality();

            //Assert
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void SulfurasCannotBeSold()
        {
            //Arrange
            IList<Item> Items = new List<Item> { CreateAnItem(ItemNames.Sulfuras, 80, 1) };
            GildedRose sut = new GildedRose(Items);

            //Act
            sut.UpdateQuality();

            //Assert
            Assert.Equal(1, Items[0].SellIn);
        }

        [Fact]
        public void SulfurasDoesNotChangeInQuality()
        {
            //Arrange
            IList<Item> Items = new List<Item> { CreateAnItem(ItemNames.Sulfuras, 80, 1) };
            GildedRose sut = new GildedRose(Items);

            //Act
            sut.UpdateQuality();

            //Assert
            Assert.Equal(80, Items[0].Quality);
        }


        [Theory]
        [InlineData(5, 15, 6)]
        [InlineData(5, 10, 7)]
        [InlineData(5, 8, 7)]
        [InlineData(5, 5, 8)]
        [InlineData(5, 3, 8)]
        public void BackstagepassesIncreasesInQualityAtEndofDay(int quality, int sellin, int expectedQuality)
        {
            //Arrange
            IList<Item> Items = new List<Item> { CreateAnItem(ItemNames.Backstagepasses, quality, sellin) };
            GildedRose sut = new GildedRose(Items);

            //Act
            sut.UpdateQuality();

            //Assert
            Assert.Equal(expectedQuality, Items[0].Quality);
        }

        [Theory]
        [InlineData(50, 0)]
        [InlineData(50, -1)]
        [InlineData(20, 0)]
        [InlineData(20, -1)]
        [InlineData(1, 0)]
        [InlineData(0, -1)]
        public void BackstagepassesReduceInQualityToZeroAfterConcert(int quality, int sellin)
        {
            //Arrange
            IList<Item> Items = new List<Item> { CreateAnItem(ItemNames.Backstagepasses, quality, sellin) };
            GildedRose sut = new GildedRose(Items);

            //Act
            sut.UpdateQuality();

            //Assert
            Assert.Equal(0, Items[0].Quality);
        }

        private Item CreateAnItem(string name, int quality, int sellin)
        {
            return ItemBuilder
                .Create()
                .WithName(name)
                .WithQuality(quality)
                .WithSellIn(sellin)
                .Build();
        }
    }
}
