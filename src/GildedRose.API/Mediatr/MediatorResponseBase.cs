namespace GildedRose.API.Mediatr
{
    public class MediatorResponseBase
    {
        public IList<string> Errors { get; set; }
        public IList<string> UserErrors { get; set; }
        public bool IsSuccess => !Errors.Any() && !UserErrors.Any();
    }
}
