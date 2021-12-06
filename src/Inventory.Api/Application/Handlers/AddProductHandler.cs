using AutoMapper;
using MediatR;
using TheVideoGameStore.Inventory.Api.Application.Commands;
using TheVideoGameStore.Inventory.Api.Application.Responses;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;

namespace TheVideoGameStore.Inventory.Api.Application.Handlers;

public class AddProductHandler : IRequestHandler<AddProductCommand, ProductResponse>
{
    private readonly IProductRepository _productsRepository;
    private readonly IMapper _mapper;

    public AddProductHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productsRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductResponse> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request);
        product = await _productsRepository.AddProductAsync(product, cancellationToken: cancellationToken);
        var result = _mapper.Map<ProductResponse>(product);
        return result;
    }
}
