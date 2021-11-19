using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Linq;
using TheVideoGameStore.Inventory.Data.Abstractions;
using TheVideoGameStore.Inventory.Models;
using TheVideoGameStore.Inventory.Repositories.Abstractions;

namespace TheVideoGameStore.Inventory.Repositories.Tests;
public class ProductRepositoryTests : TestsBase
{
    private readonly Data.Models.Product[] _testData = new Data.Models.Product[]
    {
        new()
        {
            ProductDefinition = new Data.Models.ProductDefinition
            {
                Name = "Game 01",
                Description = "Some description of game 01"
            },
            Platform = new Data.Models.Platform
            {
                Name = Platform.Playstation4.ToString()
            },
            ProductType = new Data.Models.ProductType
            {
                Identifier = ProductType.VideoGame.ToString()
            },
            ReleaseDate = new System.DateTime(2021, 12, 25)
        },
        new()
        {
            ProductDefinition = new Data.Models.ProductDefinition
            {
                Name = "Game 02",
                Description = "Some description of game 01"
            },
            Platform = new Data.Models.Platform
            {
                Name = Platform.Playstation4.ToString()
            },
            ProductType = new Data.Models.ProductType
            {
                Identifier = ProductType.VideoGame.ToString()
            },
            ReleaseDate = new System.DateTime(2021, 12, 25)
        },
        new()
        {
            ProductDefinition = new Data.Models.ProductDefinition
            {
                Name = "Playstation 5 controller",
                Description = "Some description of a playstation 5 controller"
            },
            Platform = new Data.Models.Platform
            {
                Name = Platform.Playstation5.ToString()
            },
            ProductType = new Data.Models.ProductType
            {
                Identifier = ProductType.Accessory.ToString()
            },
            ReleaseDate = new System.DateTime(2021, 12, 25)
        },
        new()
        {
            ProductDefinition = new Data.Models.ProductDefinition
            {
                Name = "Game 03",
                Description = "Some description of game 03"
            },
            Platform = new Data.Models.Platform
            {
                Name = Platform.XboxSeriesX.ToString()
            },
            ProductType = new Data.Models.ProductType
            {
                Identifier = ProductType.VideoGame.ToString()
            },
            ReleaseDate = new System.DateTime(2021, 12, 25)
        },
        new()
        {
            ProductDefinition = new Data.Models.ProductDefinition
            {
                Name = "Playstation 4 controller",
                Description = "Some description of a playstation 4 controller"
            },
            Platform = new Data.Models.Platform
            {
                Name = Platform.Playstation4.ToString()
            },
            ProductType = new Data.Models.ProductType
            {
                Identifier = ProductType.Accessory.ToString()
            },
            ReleaseDate = new System.DateTime(2021, 12, 25)
        },
    };

    [Test]
    public void Test_GetAll_SuccessAll()
    {
        //Arrange
        var productRepository = ServiceProvider.GetService<IProductRepository>();

        //Act
        var results = productRepository.GetAll();

        //Assert
        Assert.AreEqual(_testData.Length, results.Count());
    }

    [TestCase(Platform.Playstation4, ProductType.VideoGame, 2)]
    [TestCase(Platform.Playstation4, ProductType.Accessory, 1)]
    [TestCase(Platform.Playstation4, null, 3)]
    [TestCase(Platform.XboxSeriesX, ProductType.VideoGame, 1)]
    [TestCase(Platform.XboxSeriesX, ProductType.Accessory, 0)]
    [TestCase(Platform.Playstation5, ProductType.Accessory, 1)]
    [TestCase(Platform.Playstation5, null, 1)]
    [TestCase(null, null, 5)]
    [TestCase(null, ProductType.Accessory, 2)]
    [TestCase(null, ProductType.VideoGame, 3)]
    public void Test_GetAll_Success(Platform? platform, ProductType? productType, int expectedResults)
    {
        //Arrange
        var productRepository = ServiceProvider.GetService<IProductRepository>();

        //Act
        var results = productRepository.GetAll(platform: platform, productType: productType);

        //Assert
        Assert.AreEqual(expectedResults, results.Count());

        foreach (var entry in results)
        {
            Assert.AreEqual(platform ?? entry.Platform, entry.Platform);
            Assert.AreEqual(productType ?? entry.ProductType, entry.ProductType);
        }
    }

    protected override void ConfigureTestData(IInventoryDbContext dbContext)
    {
        base.ConfigureTestData(dbContext);

        dbContext.Products.AddRange(_testData);
        dbContext.SaveChanges();
    }
}