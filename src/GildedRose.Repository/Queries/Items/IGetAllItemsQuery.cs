using GildedRose.Repository.Models;

namespace GildedRose.Repository.Queries.Items
{
    public interface IGetAllItemsQuery : IEnumeratedQuery
    {
        new Task<IEnumerable<Item>> ExecuteAsync(CancellationToken cancellationToken = default);
    }
}
