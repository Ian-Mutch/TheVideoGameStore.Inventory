using MediatR;
using TheVideoGameStore.Inventory.Api.Application.Commands.Products;
using TheVideoGameStore.Inventory.Domain.AggregatesModel.ProductAggregate;

namespace TheVideoGameStore.Inventory.Api.Application.Handlers.Products;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IProductRepository _productsRepository;

    public UpdateProductHandler(IProductRepository productRepository)
    {
        _productsRepository = productRepository;
    }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productsRepository.GetByIdAsync(request.Id, cancellationToken: cancellationToken);
        if (product == null)
            return false;

        await _productsRepository.UpdateAsync(request.Id, product, cancellationToken: cancellationToken);
        return true;
    }
}
