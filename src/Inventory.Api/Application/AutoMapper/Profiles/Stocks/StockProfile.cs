using AutoMapper;
using System.Linq;
using TheVideoGameStore.Inventory.Api.Application.Responses;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.StockAggregate;
using TheVideoGameStore.Inventory.Domain.SeedWork;

namespace TheVideoGameStore.Inventory.Api.Application.AutoMapper.Profiles.Stocks;

class StockProfile : Profile
{
    public StockProfile()
    {
        CreateMap<Stock, StockResponse>()
            .ForMember(x => x.Id, config => config.MapFrom(x => x.Guid))
            .ForMember(x => x.ProductId, config => config.MapFrom(x => x.Product.Guid))
            .ForMember(x => x.Condition, config => config.MapFrom(x => Enumeration.GetAll<Condition>().Single(pt => pt.Id == x.ConditionId).Name));
    }
}
