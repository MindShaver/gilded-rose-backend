namespace GildedRose.API.ApiRequests.Items
{
    public class PostItemRequest
    {
        public string Name { get; set; }
        public int Quality { get; set; }
        public int Quantity { get; set; }
        public int Sellin { get; set; }
    }
}
