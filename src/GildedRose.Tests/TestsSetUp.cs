using System.Collections.Generic;
using GildedRose.Console;

namespace GildedRose.Tests
{
	public static class TestsSetUp
	{
		public static Item UpdateQuality(this Item item)
		{
			var program = new Program { Items = new List<Item> { item } };
			program.UpdateQuality();

			return item;
		}
	}
}
