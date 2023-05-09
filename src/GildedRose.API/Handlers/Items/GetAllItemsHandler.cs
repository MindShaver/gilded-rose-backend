using GildedRose.API.Requests.Items;
using GildedRose.Repository.Models;
using GildedRose.Repository.Queries.Items;
using MediatR;

namespace GildedRose.API.Handlers.Items
{
    public class GetAllItemsHandler : IRequestHandler<GetAllItemsRequest, IEnumerable<Item>>
    {
        private readonly IGetAllItemsQuery _query;

        public GetAllItemsHandler(IGetAllItemsQuery query)
        {
            _query = query;
        }

        public async Task<IEnumerable<Item>> Handle(GetAllItemsRequest request, CancellationToken cancellationToken)
        {
            var result = await _query.ExecuteAsync(cancellationToken);

            return result.ToList();
        }
    }
}
