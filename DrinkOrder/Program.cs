using System;
using System.Collections.Generic;
using System.Text;

using DrinkOrder.Model;
using DrinkOrder.ViewModel;

namespace DrinkOrder
{
	class Program
	{

		/// <summary>
		/// Print the list of drinks or additives to console
		/// </summary>
		/// <param name="dict">What should be printed</param>
		/// <param name="header">Header string before the table</param>
		static void PrintDictionary(IDictionary<int, DrinkComponent> dict, string header)
		{
			Console.WriteLine("/*--------------------------------------*/");
			Console.WriteLine(header);
			foreach (var item in dict.Values)
			{
				Console.WriteLine("{0,-5} {1,-25} ${2:F2}", item.Id, item.Name, item.Price);
			}
			Console.WriteLine();
		}
		
		static void Main()
		{
			var drinks = ComponentSet.Drinks;
			var additives = ComponentSet.Additives;
			PrintDictionary(drinks, "Today's drink menu:");
			PrintDictionary(additives, "You also can choose extras:");

			// error info if some of additive ids were incorrect
			var sb = new StringBuilder();

			while (true)
			{
				Console.Write("{0}Please input the drink number: ", Environment.NewLine);
				// parse input
				var drinkInput = Console.ReadLine();

				int id;
				if (!int.TryParse(drinkInput, out id))
				{
					Console.WriteLine("Please input only the drink number.");
					continue;
				}
				if (!drinks.ContainsKey(id))
				{
					Console.WriteLine("Sorry, we don't have such drink here.");
					continue;
				}
				var price = drinks[id].Price;

				Console.Write("Please enter numbers of extras separated by comma. If no extras needed, just press Enter: ");
				var addInput = Console.ReadLine();
				if (addInput == null) 
					continue;

				var adds = addInput.Split(new []{','}, StringSplitOptions.RemoveEmptyEntries);
				foreach (var item in adds)
				{
					if (!int.TryParse(item, out id)
						|| !additives.ContainsKey(id))
					{
						sb.AppendFormat("{0}, ", item);
					}
					else
					{
						price += additives[id].Price;
					}
				}
				Console.WriteLine("Total: ${0:F2}", price);
				
				// some incorrect addition ids found
				if (sb.Length > 0)
				{
					Console.WriteLine("Unfortunately, we could not find following numbers of extras: {0}", sb.ToString().TrimEnd(',', ' '));
					sb.Clear();
				}
			} // end fo main cycle
			// ReSharper disable once FunctionNeverReturns - user may close console window any time
		}
	}
}
