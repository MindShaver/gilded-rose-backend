using GildedRose.API.Engine;
using GildedRose.API.Requests.Items;
using GildedRose.Repository.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GildedRose.API.Controllers
{
    [ApiController]
    [Route("process")]
    public class DailyProcessController : ControllerBase
    {
        private IMediator _mediator;
        private readonly DailyProcessor _processor;

        public DailyProcessController(IMediator mediator)
        {
            _mediator = mediator;
            _processor = new DailyProcessor();
        }

        [HttpPost]
        public async Task<IActionResult> DailyProcess()
        {
            var getAllItemsRequest = new GetAllItemsRequest();
            var items = await _mediator.Send(getAllItemsRequest);

            _processor.UpdateQuality(items.ToList());

            var processRequest = new UpdateProcessedItemsRequest(items);
            await _mediator.Send(processRequest);

            return Ok(items);
        }
    }
}
