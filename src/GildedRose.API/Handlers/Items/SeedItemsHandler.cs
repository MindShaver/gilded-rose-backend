using GildedRose.API.Mediatr;
using GildedRose.API.Requests.Items;
using GildedRose.Repository.Commands.Items;
using MediatR;

namespace GildedRose.API.Handlers.Items
{
    public class SeedItemsHandler : IRequestHandler<SeedItemsRequest, CommandResponse>
    {
        private readonly ISeedItemsCommand _command;
        private Random random = new Random();

        public SeedItemsHandler(ISeedItemsCommand command)
        {
            _command = command;
        }

        public async Task<CommandResponse> Handle(SeedItemsRequest request, CancellationToken cancellationToken = default)
        {
            var response = new CommandResponse();

            await _command.ExecuteAsync(request.Items, cancellationToken);

            return response;
        }
    }
}
