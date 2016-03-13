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
			// избыточно в данном случае, но позволяет создать необходимый уровень абстракции
			var dp = new DataProvider();
			Drinks = dp.DataReader.Drinks;
			Additives = dp.DataReader.Additives;
		}

	}
}
