using AutoMapper;
using MediatR;
using TheVideoGameStore.Inventory.Api.Application.Queries.Stocks;
using TheVideoGameStore.Inventory.Api.Application.Responses;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.StockAggregate;

namespace TheVideoGameStore.Inventory.Api.Application.Handlers.Stocks;

public class GetStockByIdHandler : IRequestHandler<GetStockByIdQuery, StockResponse>
{
    private readonly IStockRepository _stockRepository;
    private readonly IMapper _mapper;

    public GetStockByIdHandler(IStockRepository stockRepository, IMapper mapper)
    {
        _stockRepository = stockRepository;
        _mapper = mapper;
    }

    public async Task<StockResponse> Handle(GetStockByIdQuery request, CancellationToken cancellationToken)
    {
        var stock = await _stockRepository.GetByIdAsync(request.Id, cancellationToken: cancellationToken);
        var result = _mapper.Map<StockResponse>(stock);
        return result;
    }
}