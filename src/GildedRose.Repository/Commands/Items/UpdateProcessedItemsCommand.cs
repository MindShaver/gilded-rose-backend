using GildedRose.Repository.Models;
using MediatR;

namespace GildedRose.Repository.Commands.Items
{
    public class UpdateProcessedItemsCommand : IUpdateProcessedItemsCommand
    {

        private readonly GildedDbContext _context;

        public UpdateProcessedItemsCommand(GildedDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> ExecuteAsync(IList<Item> itemsToUpdate, CancellationToken cancellationToken = default)
        {
            itemsToUpdate.ToList().ForEach(x => _context.Items.Update(x));
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

