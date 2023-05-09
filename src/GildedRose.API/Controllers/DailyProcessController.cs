using GildedRose.API.Engine;
using GildedRose.Repository.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GildedRose.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DailyProcessController : ControllerBase
    {
        private IMediator _mediator;
        private DailyProcessor _processor;

        public DailyProcessController(IMediator mediator)
        {
            _mediator = mediator;
            _processor = new DailyProcessor();
        }

        [HttpPost]
        public async Task<IActionResult> DailyProcess()
        {
            // TODO: Get all items from Mediator
            var items = new List<Item>();

            _processor.UpdateQuality(items);

            // TODO: Update all items using Mediator

            return await Task.FromResult(Ok());
        }
    }
}
