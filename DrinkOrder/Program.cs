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
			PrintDictionary(drinks, "Вашему вниманию предлагаются напитки:");
			PrintDictionary(additives, "Вы также можете выбрать добавки:");

			// error info if some of additive ids were incorrect
			var sb = new StringBuilder();

			while (true)
			{
				Console.Write("{0}Введите номер напитка: ", Environment.NewLine);
				// parse input
				var drinkInput = Console.ReadLine();

				int id;
				if (!int.TryParse(drinkInput, out id))
				{
					Console.WriteLine("Пожалуйста, введите только номер напитка.");
					continue;
				}
				if (!drinks.ContainsKey(id))
				{
					Console.WriteLine("Извините, у нас такого напитка нет.");
					continue;
				}
				var price = drinks[id].Price;

				Console.Write("Введите номера добавок через запятую. Если добавки не требуются, просто нажмите клавишу Enter: ");
				var addInput = Console.ReadLine();
				if (addInput == null) 
					continue;

				var adds = addInput.Split(',');
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
				Console.WriteLine("Стоимость: ${0:F2}", price);
				
				// some incorrect addition ids found
				if (sb.Length > 0)
				{
					Console.WriteLine("К сожалению, мы не смогли найти добавки со следующими номерами: {0}", sb.ToString().TrimEnd(',', ' '));
					sb.Clear();
				}
			} // end fo main cycle
			// ReSharper disable once FunctionNeverReturns - user may close console window any time
		}
	}
}
