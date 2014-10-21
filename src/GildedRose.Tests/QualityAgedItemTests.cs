using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
	[TestFixture]
	public class QualityAgedItemTests
	{
		[Test]
		public void Should_increase_in_quality()
		{
			var item = new Item { Name = "Aged Brie", Quality = 1, SellIn = 1 }.UpdateQuality();
			Assert.That(item.Quality, Is.EqualTo(2));
		}

		[Test]
		public void Should_never_have_quality_above_fifty()
		{
			var item = new Item { Name = "Aged Brie", Quality = 50, SellIn = 1 }.UpdateQuality();
			Assert.That(item.Quality, Is.EqualTo(50));
		}

		[Test]
		public void Should_decrement_sell_in_normally()
		{
			var item = new Item { Name = "Aged Brie", Quality = 1, SellIn = 1 }.UpdateQuality();
			Assert.That(item.SellIn, Is.EqualTo(0));
		}

		[Test]
		public void Should_double_quality_when_sell_in_is_zero()
		{
			var item = new Item { Name = "Aged Brie", Quality = 1, SellIn = 0 }.UpdateQuality();
			Assert.That(item.Quality, Is.EqualTo(3));
		}
	}
}