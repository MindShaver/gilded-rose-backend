using GildedRose.API.Mediatr;
using GildedRose.API.Requests.Items;
using GildedRose.Repository.Commands.Items;
using MediatR;

namespace GildedRose.API.Handlers.Items
{
    public class DeleteItemByIdHandler : IRequestHandler<DeleteItemByIdRequest, CommandResponse>
    {
        private readonly IDeleteItemByIdCommand _command;

        public DeleteItemByIdHandler(IDeleteItemByIdCommand command)
        {
            _command = command;
        }

        public async Task<CommandResponse> Handle(DeleteItemByIdRequest request, CancellationToken cancellationToken)
        {
            await _command.ExecuteAsync(request.IdToDelete);

            return new CommandResponse();
        }
    }
}
