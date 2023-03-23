using ExchangeMarket.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using ExchangeMarket.DAL;
//using ExchangeMarket.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace XUnitTests
{
    public class MarketContextTests
    {
        [Fact]
        public void CanCreateInstanceOfMarketContext()
        {
            // Arrange
            DbContextOptions<MarketContext> options = new DbContextOptionsBuilder<MarketContext>()
                .UseInMemoryDatabase(databaseName: "CanCreateInstanceOfMarketContext")
                .Options;

            // Act
            MarketContext marketContext = new MarketContext(options);

            // Assert
            Assert.NotNull(marketContext);
        }

    //    [Fact]
    //    public void MarketContext_CanAddAndRetrieveItems()
    //    {

    //        // Arrange
    //        DbContextOptions<MarketContext> options = new DbContextOptionsBuilder<MarketContext>()
    //            .UseInMemoryDatabase(databaseName: "MarketContext_CanAddAndRetrieveItems")
    //            .Options;

    //        MarketContext marketContext = new MarketContext();
    //        Item item = new Item { Image = "Item 1", Description = "Good Item Will Pass The Test" };
    //        marketContext.Item.Add(item);
    //        marketContext.SaveChanges();

    //        // Act
    //        Item itemFromDb = marketContext.Item.FirstOrDefault(x => x.ItemID == item.ItemID);

    //        // Assert
    //        Assert.NotNull(itemFromDb);
    //        Assert.Equal(item.ItemID, itemFromDb.ItemID);
    //        Assert.Equal(item.Image, itemFromDb.Image);
    //        Assert.Equal(item.Description, itemFromDb.Description);
    //    }

    //    [Fact]
    //    public void MarketContext_CanAddAndRetrievePersons()
    //    {
    //        // Arrange
    //        DbContextOptions<MarketContext> options = new DbContextOptionsBuilder<MarketContext>()
    //            .UseInMemoryDatabase(databaseName: "MarketContext_CanAddAndRetrievePersons")
    //            .Options;

    //        MarketContext marketContext = new MarketContext(options);
    //        Person person = new Person { FirstMidName = "John", LastName = "Doe", Email = "john.doe@test.com" };
    //        marketContext.Persons.Add(person);
    //        marketContext.SaveChanges();

    //        // Act
    //        Person personFromDb = marketContext.Persons.FirstOrDefault(x => x.ID == person.ID);

    //        // Assert
    //        Assert.NotNull(personFromDb);
    //        Assert.Equal(person.ID, personFromDb.ID);
    //        Assert.Equal(person.FirstMidName, personFromDb.FirstMidName);
    //        Assert.Equal(person.LastName, personFromDb.LastName);
    //        Assert.Equal(person.Email, personFromDb.Email);
    //    }
    }

}
