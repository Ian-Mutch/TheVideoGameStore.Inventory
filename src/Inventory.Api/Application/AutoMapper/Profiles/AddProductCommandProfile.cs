using AutoMapper;
using System.Linq;
using TheVideoGameStore.Inventory.Api.Application.Commands;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;

namespace TheVideoGameStore.Inventory.Api.Application.AutoMapper.Profiles;

class AddProductCommandProfile : Profile
{
    public AddProductCommandProfile()
    {
        CreateMap<AddProductCommand, Product>()
            .ForMember(x => x.Id, config => config.Ignore())
            .ForMember(x => x.ProductType, config => config.Ignore())
            .ForMember(x => x.ProductTypeId,
                        config =>
                        {
                            config.DoNotAllowNull();
                            config.MapFrom(x => Domain.SeedWork.Enumeration.GetAll<ProductType>()
                                                                        .Single(pt => pt.Name.Equals(x.ProductType)).Id);
                        })
            .ForMember(x => x.Platform, config => config.Ignore())
            .ForMember(x => x.PlatformId,
                        config => config.MapFrom(x => Domain.SeedWork.Enumeration.GetAll<Platform>()
                                                                                .Single(pt => pt.Name.Equals(x.Platform)).Id));
    }
}