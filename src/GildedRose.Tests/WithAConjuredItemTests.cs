using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
	[TestFixture]
	public class with_a_conjured_item
	{
		[Test]
		public void sellIn_should_decrement_the_same_as_normal_items()
		{
			var item = new Item { Name = "Conjured Mana Cake", Quality = 1, SellIn = 1 }.UpdateQuality();
			Assert.That(item.SellIn, Is.EqualTo(0));
		}

		[Test]
		public void quality_should_decrement_twice_as_fast_as_normal_items()
		{
			var item = new Item { Name = "Conjured Mana Cake", Quality = 2, SellIn = 1 }.UpdateQuality();
			Assert.That(item.Quality, Is.EqualTo(0));
		}

		[Test]
		public void after_sell_in_date_quality_decreases_twice_as_fast_as_normal_item_past_sell_in_date()
		{
			var item = new Item { Name = "Conjured Mana Cake", Quality = 4, SellIn = -1 }.UpdateQuality();
			Assert.That(item.Quality, Is.EqualTo(0));
		}

	}
}