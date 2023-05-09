using GildedRose.Repository.Models;
using MediatR;

namespace GildedRose.API.Requests.Items
{
    public class GetAllItemsRequest : IRequest<IEnumerable<Item>>
    {
        public GetAllItemsRequest() { }
    }
}
