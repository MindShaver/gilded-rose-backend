using GildedRose.API.Mediatr;
using GildedRose.API.Requests.Items;
using GildedRose.Repository.Commands.Items;
using MediatR;

namespace GildedRose.API.Handlers.Items
{
    public class CreateItemHandler : IRequestHandler<CreateItemRequest, CommandResponse>
    {
        private readonly ICreateItemCommand _command;

        public CreateItemHandler(ICreateItemCommand command)
        {
            _command = command;
        }

        public async Task<CommandResponse> Handle(CreateItemRequest request, CancellationToken cancellationToken = default)
        {
            var response = await _command.ExecuteAsync(request.Item, cancellationToken);

            return new CommandResponse();
        }
    }
}
