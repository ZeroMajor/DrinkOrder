using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using DrinkOrder.Model;

namespace DrinkOrder.ViewModel
{
	/// <summary>
	/// Class containing information on available components for the drinks
	/// </summary>
	public static class ComponentSet
	{
		/// <summary>
		/// List of available drinks, accessible by drink Id
		/// </summary>
		public static ReadOnlyDictionary<int, DrinkComponent> Drinks;

		/// <summary>
		/// List of available additives, accessible by additive Id
		/// </summary>
		public static ReadOnlyDictionary<int, DrinkComponent> Additives;

		static ComponentSet()
		{
			Drinks = new ReadOnlyDictionary<int, DrinkComponent>(ReadDataFromFile("drinks.txt"));
			Additives = new ReadOnlyDictionary<int, DrinkComponent>(ReadDataFromFile("Additives.txt"));
		}

		/// <summary>
		/// Read data from file, parse and prepare a dictionary containing valid data
		/// </summary>
		/// <param name="fileName"></param>
		/// <returns></returns>
		private static Dictionary<int, DrinkComponent> ReadDataFromFile(string fileName)
		{
			string[] dataStrings;
			using (var file = File.OpenText(fileName))
            {
                dataStrings = file.ReadToEnd().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            }

			// dictionary will contain not more than dataStrings.Length entries
			var dict = new Dictionary<int, DrinkComponent>(dataStrings.Length);

			// prcess all records with structure like 'id;name;price'
			foreach (var split in dataStrings.Select(str => str.Trim().Split(';')).Where(split => split.Length >= 3))
			{
				int id;
				float price;
				if (int.TryParse(split[0], out id)
				    && float.TryParse(split[2], out price))
				{
					dict.Add(id, new DrinkComponent(id, price, split[1]));
				}
			}

			return dict;
		}
	}
}
