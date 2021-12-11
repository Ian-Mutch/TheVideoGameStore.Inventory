using AutoMapper;
using MediatR;
using System.Linq;
using TheVideoGameStore.Inventory.Api.Application.Commands.Stocks;
using TheVideoGameStore.Inventory.Api.Application.Responses;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.StockAggregate;
using TheVideoGameStore.Inventory.Domain.SeedWork;

namespace TheVideoGameStore.Inventory.Api.Application.Handlers.Stocks;

public class AddStockHandler : IRequestHandler<AddStockCommand, StockResponse>
{
    private readonly IStockRepository _stockRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public AddStockHandler(IStockRepository stockRepository, IProductRepository productRepository, IMapper mapper)
    {
        _stockRepository = stockRepository;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<StockResponse> Handle(AddStockCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.ProductId, cancellationToken: cancellationToken);
        var condition = Enumeration.GetAll<Condition>().Single(x => x.Name == request.Condition);
        var stock = new Stock(product, condition, request.Quantity);
        stock = await _stockRepository.AddAsync(stock, cancellationToken: cancellationToken);
        var result = _mapper.Map<StockResponse>(stock);
        return result;
    }
}
