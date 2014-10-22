using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
	[TestFixture]
	public class EventItemTests
	{
		[Test]
		public void Should_increase_in_quality()
		{
			var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 1, SellIn = 11 }.UpdateQuality();
			Assert.That(item.Quality, Is.EqualTo(2));
		}

		[TestCase(10)]
		[TestCase(9)]
		[TestCase(8)]
		[TestCase(7)]
		[TestCase(6)]
		public void Should_increase_quality_by_two_when_there_are_ten_or_less_days_left(int daysLeft)
		{
			var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 1, SellIn = daysLeft }.UpdateQuality();
			Assert.That(item.Quality, Is.EqualTo(3));
		}

		[TestCase(5)]
		[TestCase(4)]
		[TestCase(3)]
		[TestCase(2)]
		[TestCase(1)]
		public void Should_increase_quality_by_three_when_there_are_five_days_left(int daysLeft)
		{
			var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 1, SellIn = daysLeft }.UpdateQuality();
			Assert.That(item.Quality, Is.EqualTo(4));
		}

		[Test]
		public void Should_drop_quality_to_zero_when_sell_in_has_passed()
		{
			var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 1, SellIn = 0 }.UpdateQuality();
			Assert.That(item.Quality, Is.EqualTo(0));
		}

		[Test]
		public void Should_decrement_sell_in_normally()
		{
			var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 1, SellIn = 1 }.UpdateQuality();
			Assert.That(item.SellIn, Is.EqualTo(0));
		}

	    [Test]
	    public void Should_accept_backstage_passes_the_same()
	    {
	        var item = new Item {Name = "Backstage passes to Justin Bieber", Quality = 3, SellIn = 3}.UpdateQuality();
            Assert.That(item.SellIn, Is.EqualTo(2));
            Assert.That(item.Quality, Is.EqualTo(6));
	    }
	}
}