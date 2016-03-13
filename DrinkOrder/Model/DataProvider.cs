using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkOrder.Model
{
	/// <summary>
	/// Factory which creates and provides data reader class for external access
	/// </summary>
	public class DataProvider
	{
		public DataProvider()
		{
			DataReader = new FileDataReader();
		}

		public IDataReader DataReader { get; private set; }
	}
}
