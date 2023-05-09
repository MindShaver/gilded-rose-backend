

namespace GildedRose.Repository.Commands
{
    public interface ICommand<in TIn, TOut>
    {
        public Task<TOut> ExecuteAsync(TIn parameter, CancellationToken cancellationToken = default);
    }
}
