using GildedRose.API.Mediatr;
using GildedRose.Repository.Models;
using MediatR;

namespace GildedRose.API.Requests.Items
{
    public class SeedItemsRequest : IRequest<CommandResponse>
    {
        public List<Item> Items { get; set; }

        public SeedItemsRequest(List<Item> itemsToSeed)
        {
            Items = itemsToSeed;
        }
    }
}
