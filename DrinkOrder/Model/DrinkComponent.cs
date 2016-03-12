namespace DrinkOrder.Model
{
	/// <summary>
	/// Struct that contains information about drink component (base or additives)
	/// </summary>
	public struct DrinkComponent
	{
		/// <summary>
		/// Id number of the component
		/// </summary>
		public readonly int Id;
		/// <summary>
		/// Component price
		/// </summary>
		public readonly float Price;
		/// <summary>
		/// Component name
		/// </summary>
		public readonly string Name;

		/// <summary>
		/// Create new struct
		/// </summary>
		/// <param name="id">Id</param>
		/// <param name="price">Price</param>
		/// <param name="name">Name</param>
		public DrinkComponent(int id, float price, string name)
		{
			Id = id;
			Price = price;
			Name = name;
		}
	}
}
