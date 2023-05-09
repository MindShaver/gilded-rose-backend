namespace GildedRose.Repository.Queries
{
    public interface ISingleQuery
    {
        public interface ISingleQuery<in TIN, TOut>
        {
            public Task<TOut> ExecuteAsync(TIN parameter, CancellationToken cancellation = default);
        }

        public interface ISingleQuery<TOut>
        {
            public Task<TOut?> ExecuteAsync(Guid id, CancellationToken cancellationToken = default);
        }
    }
}
