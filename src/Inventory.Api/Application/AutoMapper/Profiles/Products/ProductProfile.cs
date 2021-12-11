using AutoMapper;
using System.Linq;
using TheVideoGameStore.Inventory.Api.Application.Responses;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;
using TheVideoGameStore.Inventory.Domain.SeedWork;

namespace TheVideoGameStore.Inventory.Api.Application.AutoMapper.Profiles.Products;

class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductResponse>()
            .ForMember(x => x.Id, config => config.MapFrom(x => x.Guid))
            .ForMember(x => x.ProductType, config => config.MapFrom(x => Enumeration.GetAll<ProductType>().Single(pt => pt.Id == x.ProductTypeId).Name))
            .ForMember(x => x.Platform, config => config.MapFrom(x => Enumeration.GetAll<Platform>().Single(pt => pt.Id == x.PlatformId).Name))
            .ForMember(x => x.StockQuantities, config => config.MapFrom(x => x.Stock.ToDictionary(s => s.Condition.Name, s => s.Quantity)));
    }
}
