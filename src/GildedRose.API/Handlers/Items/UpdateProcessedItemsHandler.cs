using GildedRose.API.Mediatr;
using GildedRose.API.Requests.Items;
using GildedRose.Repository.Commands.Items;
using MediatR;

namespace GildedRose.API.Handlers.Items
{
    public class UpdateProcessedItemsHandler : IRequestHandler<UpdateProcessedItemsRequest, CommandResponse>
    {
        private readonly IUpdateProcessedItemsCommand _command;

        public UpdateProcessedItemsHandler(IUpdateProcessedItemsCommand command)
        {
            _command = command;
        }

        public async Task<CommandResponse> Handle(UpdateProcessedItemsRequest request, CancellationToken cancellationToken = default)
        {
            var response = new CommandResponse();

            await _command.ExecuteAsync(request.Items.ToList(), cancellationToken);

            return response;
        }
    }
}
