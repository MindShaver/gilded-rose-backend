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
            //TODO: Get all items using Mediator
            var items = new List<Item>();

            return await Task.FromResult(Ok(items));
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

            return await Task.FromResult(Ok(items));
        }
    }
}
