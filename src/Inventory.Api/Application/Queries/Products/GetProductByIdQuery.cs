using MediatR;
using TheVideoGameStore.Inventory.Api.Application.Responses;

namespace TheVideoGameStore.Inventory.Api.Application.Queries.Products;

public class GetProductByIdQuery : IRequest<ProductResponse>
{
    public Guid Id { get; }

    public GetProductByIdQuery(Guid id) => Id = id;
}
