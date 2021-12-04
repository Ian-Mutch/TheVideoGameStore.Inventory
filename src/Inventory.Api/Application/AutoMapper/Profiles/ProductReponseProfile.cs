using AutoMapper;
using TheVideoGameStore.Inventory.Api.Application.Responses;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;

namespace TheVideoGameStore.Inventory.Api.Application.AutoMapper.Profiles;

class ProductReponseProfile : Profile
{
    public ProductReponseProfile()
    {
        CreateMap<Product, ProductResponse>()
            .ForMember(x => x.ProductType, config => config.MapFrom(x => x.ProductType.Name))
            .ForMember(x => x.Platform, config => config.MapFrom(x => x.Platform.Name));
    }
}
