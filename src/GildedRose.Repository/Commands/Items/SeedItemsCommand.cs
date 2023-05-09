using GildedRose.Repository.Models;
using MediatR;

namespace GildedRose.Repository.Commands.Items
{
    public class SeedItemsCommand : ISeedItemsCommand
    {
        private readonly GildedDbContext _context;

        public SeedItemsCommand(GildedDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> ExecuteAsync(List<Item> itemsToSeed, CancellationToken cancellationToken = default)
        {
            await _context.Items.AddRangeAsync(itemsToSeed, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
