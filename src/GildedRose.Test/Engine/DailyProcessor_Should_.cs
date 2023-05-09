using GildedRose.API.Engine;
using GildedRose.Repository.Models;

namespace GildedRoseTest.Engine
{
    public class DailyProcessor_Should_
    {
        [Fact]
        public void Update_The_Quality_Of_Aged_Brie_To_Increase_With_Time()
        {
            var testQuality = 10;
            var expectedQuality = testQuality + 1;
            Item testItem = new Item("Aged Brie", 0, testQuality, 0);

            var items = new List<Item> { testItem };

            var engine = new DailyProcessor();
            engine.UpdateQuality(items);

            var actualQuality = items.First().Quality;

            Assert.Equal(expectedQuality + 1, actualQuality);
        }
    }
}
