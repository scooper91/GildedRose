using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
	[TestFixture]
	public class LegendaryItemTests
	{
		[Test]
		public void Should_not_decrease_in_quality()
		{
			var item = new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = 1, SellIn = 1 }.UpdateQuality();
			Assert.That(item.Quality, Is.EqualTo(1));
		}

		[Test]
		public void Should_not_decrease_sell_in()
		{
			var item = new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = 1, SellIn = 1 }.UpdateQuality();
			Assert.That(item.SellIn, Is.EqualTo(1));
		}
	}
}