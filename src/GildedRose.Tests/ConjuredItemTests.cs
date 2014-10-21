using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
	[TestFixture]
	public class ConjuredItemTests
	{
		[Test]
		public void Should_decrement_sell_in_the_same_as_normal_items()
		{
			var item = new Item { Name = "Conjured Mana Cake", Quality = 1, SellIn = 1 }.UpdateQuality();
			Assert.That(item.SellIn, Is.EqualTo(0));
		}

		[Test]
		public void Should_decrement_quality_twice_as_fast_as_normal_items()
		{
			var item = new Item { Name = "Conjured Mana Cake", Quality = 2, SellIn = 1 }.UpdateQuality();
			Assert.That(item.Quality, Is.EqualTo(0));
		}

		[Test]
		public void Should_decrement_quality_twice_as_fast_as_normal_items_after_sell_in_date()
		{
			var item = new Item { Name = "Conjured Mana Cake", Quality = 4, SellIn = -1 }.UpdateQuality();
			Assert.That(item.Quality, Is.EqualTo(0));
		}

	}
}