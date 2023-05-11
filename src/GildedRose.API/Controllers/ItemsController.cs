using GildedRose.API.Requests.Items;
using GildedRose.Repository.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GildedRose.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private IMediator _mediatr;

        public ItemsController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var request = new GetAllItemsRequest();
            var items = await _mediatr.Send(request);

            return Ok(items);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAll()
        {
            var getAllItemsRequest = new GetAllItemsRequest();
            var itemsToDelete = await _mediatr.Send(getAllItemsRequest);

            var deleteAllItemsRequest = new DeleteAllItemsRequest(itemsToDelete);
            await _mediatr.Send(deleteAllItemsRequest);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> SeedData()
        {
            var items = new List<Item>
            {
                new Item("Regular Item", quantity: 10, quality: 20, sellIn: 15),
                new Item("Aged Brie", quantity: 5, quality: 25, sellIn: 10),
                new Item("Backstage passes to a TAFKAL80ETC concert", quantity: 5, quality: 30, sellIn: 12),
                new Item("Backstage passes to a TAFKAL80ETC concert", quantity: 5, quality: 30, sellIn: 10),
                new Item("Backstage passes to a TAFKAL80ETC concert", quantity: 5, quality: 30, sellIn: 5),
                new Item("Sulfuras, Hand of Ragnaros", quantity: 1, quality: 80, sellIn: 0),
                new Item("Expired Regular Item", quantity: 10, quality: 20, sellIn: -1),
                new Item("Aged Brie", quantity: 5, quality: 25, sellIn: -2),
                new Item("Backstage passes to a TAFKAL80ETC concert", quantity: 5, quality: 30, sellIn: -3)
            };

            // TODO: Check to see if there are already items in the database. If yes - do nothing. If no - add items to DB
            var request = new SeedItemsRequest(items);
            await _mediatr.Send(request);

            return await Task.FromResult(Ok(items));
        }
    }
}
