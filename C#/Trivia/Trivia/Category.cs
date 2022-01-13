using System.Collections.Generic;

namespace Trivia
{
	public class Category
	{
		public static Category Pop     { get; } = new Category("Pop");
		public static Category Science { get; } = new Category("Science");
		public static Category Sports  { get; } = new Category("Sports");
		public static Category Rock    { get; } = new Category("Rock");

		private readonly string   _description;

		private Category(string description) => this._description = description;

		public static IEnumerable<Category> Categories { get; } = new List<Category>() { Pop, Science, Sports, Rock};

		public override string ToString() => this._description;
	}
}