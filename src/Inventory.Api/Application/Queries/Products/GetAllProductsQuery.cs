using MediatR;
using TheVideoGameStore.Inventory.Api.Application.Responses;

namespace TheVideoGameStore.Inventory.Api.Application.Queries.Products;

public class GetAllProductsQuery : IRequest<List<ProductResponse>>
{
    public string ProductType { get; init; }
    public string Platform { get; init; }
}