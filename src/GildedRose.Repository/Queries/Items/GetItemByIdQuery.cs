using GildedRose.Repository.Models;

namespace GildedRose.Repository.Queries.Items
{
    public class GetItemByIdQuery : IGetItemByIdQuery
    {
        private GildedDbContext _context;

        public GetItemByIdQuery(GildedDbContext context)
        {
            _context = context;
        }

        public async Task<Item> ExecuteAsync(Guid itemId, CancellationToken cancellationToken)
        {
            var item = await _context.Items.FindAsync(itemId);

            return item;
        }
    }
}
