using GildedRose.API.Mediatr;
using GildedRose.Repository.Models;
using MediatR;

namespace GildedRose.API.Requests.Items
{
    public class CreateItemRequest : IRequest<CommandResponse>
    {
        public Item Item { get; set; }

        public CreateItemRequest(Item item)
        {
            Item = item;
        }
    }
}
