using GildedRose.Repository.Models;
using MediatR;
namespace GildedRose.Repository.Commands.Items
{
    public class CreateItemCommand : ICreateItemCommand
    {
        private readonly GildedDbContext _context;

        public CreateItemCommand(GildedDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> ExecuteAsync(Item itemToCreate, CancellationToken cancellationToken = default)
        {
            await _context.Items.AddAsync(itemToCreate, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
