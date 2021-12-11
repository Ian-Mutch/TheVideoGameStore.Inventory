using AutoMapper;
using MediatR;
using TheVideoGameStore.Inventory.Api.Application.Queries.Products;
using TheVideoGameStore.Inventory.Api.Application.Responses;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;

namespace TheVideoGameStore.Inventory.Api.Application.Handlers.Products;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<ProductResponse>>
{
    private readonly IProductRepository _productsRepository;
    private readonly IMapper _mapper;

    public GetAllProductsHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productsRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<List<ProductResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productsRepository.GetAllAsync(platform: request.Platform, productType: request.ProductType, cancellationToken: cancellationToken);
        var result = _mapper.Map<List<ProductResponse>>(products);
        return result;
    }
}
