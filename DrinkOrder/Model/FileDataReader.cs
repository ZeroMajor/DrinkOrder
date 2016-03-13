using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace DrinkOrder.Model
{
	/// <summary>
	/// Data reader which accesses data in files
	/// </summary>
	public class FileDataReader : IDataReader
	{
		public ReadOnlyDictionary<int, DrinkComponent> Drinks { get; private set; }

		public ReadOnlyDictionary<int, DrinkComponent> Additives { get; private set; }

		public FileDataReader()
		{
			Drinks = new ReadOnlyDictionary<int, DrinkComponent>(ReadDataFromFile("drinks.txt"));
			Additives = new ReadOnlyDictionary<int, DrinkComponent>(ReadDataFromFile("Additives.txt"));
		}

		/// <summary>
		/// Read data from file, parse and prepare a dictionary containing valid data.
		/// </summary>
		/// <param name="fileName"></param>
		/// <returns>Dictionary where keys are Ids and values are actual data structs.<para/>Empty if data access error occured.</returns>
		private static Dictionary<int, DrinkComponent> ReadDataFromFile(string fileName)
		{
			string[] dataStrings;

			StreamReader file = null;
			try
			{
				file = File.OpenText(fileName);
				dataStrings = file.ReadToEnd().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
			}
			catch
			{
				// hide data access errors, should return empty data instead
				// TODO - log errors using e.g. NLog
				dataStrings = new string[] { };
			}
			finally
			{
				if (file != null)
					file.Dispose();
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
