using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
	[TestFixture]
	public class StandardItemTests
	{

		[Test]
		public void Should_decrement_sell_in()
		{
			var item = new Item {Name = "standard item", SellIn = 1, Quality = 1 }.UpdateQuality();
			Assert.That(item.SellIn, Is.EqualTo(0));
		}

		[Test]
		public void Should_decrement_quality()
		{
			var item = new Item { Name = "standard item", SellIn = 1, Quality = 1 }.UpdateQuality();
			Assert.That(item.Quality, Is.EqualTo(0));
		}

		[Test]
		public void Should_decrement_quality_twice_as_fast_when_sell_in_passed()
		{
			var item = new Item { Name = "standard item", SellIn = 0, Quality = 2 }.UpdateQuality();
			Assert.That(item.Quality, Is.EqualTo(0));
		}

		[Test]
		public void Should_never_have_negative_quality()
		{
			var item = new Item { Name = "standard item", SellIn = 1, Quality = 0 }.UpdateQuality();
			Assert.That(item.Quality, Is.EqualTo(0));
		}
	}
}