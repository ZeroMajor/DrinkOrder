using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkOrder.Model
{
	/// <summary>
	/// Interface for actual reader which fetches data from storage
	/// </summary>
	public interface IDataReader
	{
		/// <summary>
		/// List of available drinks, accessible by drink Id
		/// </summary>
		ReadOnlyDictionary<int, DrinkComponent> Drinks { get; }

		/// <summary>
		/// List of available additives, accessible by additive Id
		/// </summary>
		ReadOnlyDictionary<int, DrinkComponent> Additives { get; }
	}
}
