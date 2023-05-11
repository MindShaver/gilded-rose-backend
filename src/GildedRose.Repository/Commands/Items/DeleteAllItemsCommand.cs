using GildedRose.Repository.Models;
using MediatR;

namespace GildedRose.Repository.Commands.Items
{
    public class DeleteAllItemsCommand : IDeleteAllItemsCommand
    {
        private readonly GildedDbContext _context;

        public DeleteAllItemsCommand(GildedDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> ExecuteAsync(IEnumerable<Item> itemsToDelete, CancellationToken cancellationToken = default)
        {
            itemsToDelete.ToList().ForEach(x => _context.Items.Remove(x));
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
