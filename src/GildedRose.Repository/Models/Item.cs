namespace GildedRose.Repository.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public int Quantity { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? LastModifiedBy { get; set; }

        public Item(string name, int quantity, int quality, int sellIn)
        {
            Id = Guid.NewGuid();
            Name = name;
            SellIn = sellIn;
            Quality = quality;
            Quantity = quantity;
            IsDeleted = false;
            CreatedOn = DateTime.UtcNow;
            CreatedBy = Guid.NewGuid();
            LastModifiedOn = null;
            LastModifiedBy = null;
        }
    }
}
