using GildedRose.API.Requests.Items;
using GildedRose.Repository.Models;
using GildedRose.Repository.Queries.Items;
using MediatR;

namespace GildedRose.API.Handlers.Items
{
    public class GetItemByIdHandler : IRequestHandler<GetItemByIdRequest, Item>
    {
        private readonly IGetItemByIdQuery _query;

        public GetItemByIdHandler(IGetItemByIdQuery query)
        {
            _query = query;
        }

        public async Task<Item> Handle(GetItemByIdRequest request, CancellationToken cancellationToken)
        {
            var result = await _query.ExecuteAsync(request.ItemId, cancellationToken);

            return result;
        }
    }
}
