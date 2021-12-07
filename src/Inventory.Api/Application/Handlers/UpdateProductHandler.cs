using AutoMapper;
using MediatR;
using TheVideoGameStore.Inventory.Api.Application.Commands;
using TheVideoGameStore.Inventory.Api.Application.Responses;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;

namespace TheVideoGameStore.Inventory.Api.Application.Handlers;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ProductResponse>
{
    private readonly IProductRepository _productsRepository;
    private readonly IMapper _mapper;

    public UpdateProductHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productsRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request);
        product = await _productsRepository.UpdateProductAsync(request.Id, product, cancellationToken: cancellationToken);
        return _mapper.Map<ProductResponse>(product);
    }
}
