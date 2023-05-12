using MediatR;

namespace GildedRose.Repository.Commands.Items
{
    public class DeleteItemByIdCommand : IDeleteItemByIdCommand
    {
        private readonly GildedDbContext _context;

        public DeleteItemByIdCommand(GildedDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> ExecuteAsync(Guid idToDelete, CancellationToken cancellationToken = default)
        {
            var itemToDelete = await _context.Items.FindAsync(idToDelete);

            _context.Remove(itemToDelete!);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
