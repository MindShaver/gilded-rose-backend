using GildedRose.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace GildedRose.Repository.Queries.Items
{
    public class GetAllItemsQuery : IGetAllItemsQuery
    {
        private GildedDbContext _context;

        public GetAllItemsQuery(GildedDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Item>> ExecuteAsync( CancellationToken cancellationToken)
        {
            var items = await _context.Items.Where(x => !x.IsDeleted).ToListAsync();

            return items;
        }
    }
}
