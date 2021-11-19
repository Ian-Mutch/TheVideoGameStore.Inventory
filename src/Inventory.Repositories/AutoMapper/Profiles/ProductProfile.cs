using AutoMapper;
using TheVideoGameStore.Inventory.Models;

namespace TheVideoGameStore.Inventory.Repositories.AutoMapper.Profiles;

class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Data.Models.Product, Product>()
            .IncludeMembers(x => x.ProductDefinition)
            .ForMember(x => x.Id, config => config.MapFrom(x => x.ProductId))
            .ForMember(x => x.ProductType, config => config.MapFrom(x => Enum.Parse<ProductType>(x.ProductType.Identifier)))
            .ForMember(x => x.Platform, config => config.MapFrom(x => Enum.Parse<Platform>(x.Platform.Name)));

        CreateMap<Data.Models.ProductDefinition, Product>();
    }
}
