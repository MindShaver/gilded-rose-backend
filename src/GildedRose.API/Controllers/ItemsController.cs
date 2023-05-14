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
        private readonly IMediator _mediator;

        public ItemsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var request = new GetAllItemsRequest();
                var items = await _mediator.Send(request);

                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var request = new GetItemByIdRequest(id);
                var item = await _mediator.Send(request);

                if (item != null)
                {
                    return Ok(item);
                }

                return NotFound($"Item with id - {id} not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            try
            {
                var request = new DeleteItemByIdRequest(id);
                await _mediator.Send(request);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAll()
        {
            try
            {
                var getAllItemsRequest = new GetAllItemsRequest();
                var itemsToDelete = await _mediator.Send(getAllItemsRequest);

                var deleteAllItemsRequest = new DeleteAllItemsRequest(itemsToDelete);
                await _mediator.Send(deleteAllItemsRequest);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PostItemRequest request)
        {
            try
            {
                var itemToCreate = new Item(request.Name, request.Quantity, request.Quantity, request.Sellin);
                var createRequest = new CreateItemRequest(itemToCreate);
                var response = await _mediator.Send(createRequest);

                // Assuming that the response contains the id of the newly created item.
                return CreatedAtAction(nameof(GetById), new { id = itemToCreate.Id }, itemToCreate);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpPost("~/seed")]
        public async Task<IActionResult> SeedData()
        {
            try
            {
                var request = new GetAllItemsRequest();
                var items = await _mediator.Send(request);

                if (items.Any())
                {
                    return Ok();
                }

                var seedItems = GetSeedItems();

                var seedRequest = new SeedItemsRequest(seedItems);
                await _mediator.Send(seedRequest);

                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        private List<Item> GetSeedItems()
        {
            return new List<Item>
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
        }
    }
}
 



