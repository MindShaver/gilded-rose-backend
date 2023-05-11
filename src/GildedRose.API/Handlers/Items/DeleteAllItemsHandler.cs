using GildedRose.API.Mediatr;
using GildedRose.API.Requests.Items;
using GildedRose.Repository.Commands.Items;
using MediatR;

namespace GildedRose.API.Handlers.Items
{
    public class DeleteAllItemsHandler : IRequestHandler<DeleteAllItemsRequest, CommandResponse>
    {
        private readonly IDeleteAllItemsCommand _command;

        public DeleteAllItemsHandler(IDeleteAllItemsCommand command)
        {
            _command = command;
        }

        public async Task<CommandResponse> Handle(DeleteAllItemsRequest request, CancellationToken cancellationToken = default)
        {
            var response = new CommandResponse();

            await _command.ExecuteAsync(request.Items, cancellationToken);

            return response;
        }
    }
}
