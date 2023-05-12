using GildedRose.API.Mediatr;
using MediatR;

namespace GildedRose.API.Requests.Items
{
    public class DeleteItemByIdRequest : IRequest<CommandResponse>
    {
        public Guid IdToDelete { get; set; }

        public DeleteItemByIdRequest(Guid idToDelete)
        {
            IdToDelete = idToDelete;
        }
    }
}
