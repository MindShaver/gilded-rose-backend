namespace GildedRose.Repository.Queries
{
    public interface IEnumeratedQuery
    {
        public interface IEnumeratedQuery<in TIn, TOut>
        {
            public Task<IEnumerable<TOut>> ExecuteAsync(TIn parameter, CancellationToken cancellation = default);
        }

        public interface IEnumeratedQuery<in TIn1, in TIn2, TOut>
        {
            public Task<IEnumerable<TOut>> ExecuteAsync(
                TIn1 parameter1,
                TIn2 parameter2,
                CancellationToken cancellation = default);
        }
    }
}
