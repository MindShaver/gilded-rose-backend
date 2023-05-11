using GildedRose.API.Mediatr;
using GildedRose.Repository.Models;
using MediatR;

namespace GildedRose.API.Requests.Items
{
    public class DeleteAllItemsRequest : IRequest<CommandResponse>
    {
        public IEnumerable<Item> Items { get; set; }

        public DeleteAllItemsRequest(IEnumerable<Item> itemsToDelete)
        {
            Items = itemsToDelete;
        }
    }
}
