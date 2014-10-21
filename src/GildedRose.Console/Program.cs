using System.Collections.Generic;

namespace GildedRose.Console
{
	public class Program
	{
		public IList<Item> Items;

		private static void Main()
		{
			System.Console.WriteLine("OMGHAI!");

			var app = new Program
			{
				Items = new List<Item>
				{
					new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
					new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
					new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
					new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
					new Item
					{
						Name = "Backstage passes to a TAFKAL80ETC concert",
						SellIn = 15,
						Quality = 20
					},
					new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
				}

			};

			app.UpdateQuality();

			System.Console.ReadKey();

		}

		public void UpdateQuality()
		{
			foreach (var item in Items)
			{
				var changeInQuality = 0;
				if (IsNotAgedBrie(item) && !IsBackstagePass(item))
				{
					if (item.Quality > 0)
					{
						changeInQuality = DecreaseInQuality(item, changeInQuality);
					}
				}
				else if (IsNotLegendary(item))
				{
					if (item.Quality < 50)
					{
						changeInQuality++;

						if (IsBackstagePass(item))
						{
							if (item.SellIn < 11 && item.Quality < 50)
							{
								changeInQuality++;
							}

							if (item.SellIn < 6 && item.Quality < 50)
							{
								changeInQuality++;
							}
						}
					}
				}

				if (IsNotLegendary(item))
				{
					item.SellIn -= 1;
				}

				if (item.SellIn < 0)
				{
					if (IsNotAgedBrie(item))
					{
						if (!IsBackstagePass(item))
						{
							if (item.Quality > 0)
							{
								changeInQuality = DecreaseInQuality(item, changeInQuality);
							}
						}
						else
						{
							changeInQuality = 0;
							item.Quality = 0;
						}
					}
					else
					{
						if (item.Quality < 50)
						{
							changeInQuality++;
						}
					}
				}
				item.Quality += changeInQuality;
			}
		}

		private static int DecreaseInQuality(Item item, int changeInQuality)
		{
			if (IsConjured(item))
			{
				changeInQuality -= 2;
			}
			else if (IsNotLegendary(item))
			{
				changeInQuality--;
			}
			return changeInQuality;
		}

		private static bool IsNotAgedBrie(Item item)
		{
			return item.Name != "Aged Brie";
		}

		private static bool IsBackstagePass(Item item)
		{
			return item.Name == "Backstage passes to a TAFKAL80ETC concert";
		}

		private static bool IsNotLegendary(Item item)
		{
			return item.Name != "Sulfuras, Hand of Ragnaros";
		}

		private static bool IsConjured(Item item)
		{
			return item.Name == "Conjured Mana Cake";
		}
	}

	public class Item
	{
		public string Name { get; set; }

		public int SellIn { get; set; }

		public int Quality { get; set; }
	}

}
