using GildedRose.Repository.Models;
using MediatR;

namespace GildedRose.API.Requests.Items
{
    public class GetItemByIdRequest : IRequest<Item>
    {
        public Guid ItemId { get; set; }

        public GetItemByIdRequest(Guid itemId) {
            ItemId = itemId;
        }
    }
}
