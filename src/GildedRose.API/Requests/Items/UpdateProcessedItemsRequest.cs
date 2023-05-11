using GildedRose.API.Mediatr;
using GildedRose.Repository.Models;
using MediatR;

namespace GildedRose.API.Requests.Items
{
    public class UpdateProcessedItemsRequest : IRequest<CommandResponse>
    {
        public IEnumerable<Item> Items { get; set; }

        public UpdateProcessedItemsRequest(IEnumerable<Item> itemsToUpdate)
        {
            Items = itemsToUpdate;
        }
    }
}
