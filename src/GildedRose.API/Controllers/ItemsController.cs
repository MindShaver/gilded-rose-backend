using GildedRose.API.ApiRequests.Items;
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
        private IMediator _mediator;

        public ItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var request = new GetAllItemsRequest();
            var items = await _mediator.Send(request);

            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var request = new GetItemByIdRequest(id);

            var item = await _mediator.Send(request);

            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            var request = new DeleteItemByIdRequest(id);

            await _mediator.Send(request);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAll()
        {
            var getAllItemsRequest = new GetAllItemsRequest();
            var itemsToDelete = await _mediator.Send(getAllItemsRequest);

            var deleteAllItemsRequest = new DeleteAllItemsRequest(itemsToDelete);
            await _mediator.Send(deleteAllItemsRequest);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PostItemRequest request)
        {
            var itemToCreate = new Item(request.Name, request.Quantity, request.Quantity, request.Sellin);
            var createRequest = new CreateItemRequest(itemToCreate);
            var response = await _mediator.Send(createRequest);

            return Created("", "");
        }

        [HttpPost("/seed")]
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
            await _mediator.Send(request);

            return await Task.FromResult(Ok(items));
        }
    }
}
