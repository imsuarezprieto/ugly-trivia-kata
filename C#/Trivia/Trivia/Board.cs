using System.Collections;
using System.Collections.Generic;

namespace Trivia
{
	public class Board
	{
		private static readonly IList<Place> _places = new List<Place>()
		{
				new Place(Category.Pop),
				new Place(Category.Science),
				new Place(Category.Sports),
				new Place(Category.Rock),
				new Place(Category.Pop),
				new Place(Category.Science),
				new Place(Category.Sports),
				new Place(Category.Rock),
				new Place(Category.Pop),
				new Place(Category.Science),
				new Place(Category.Sports),
				new Place(Category.Rock),
		};

		public static Place InitialPlace => _places[0];

		public class Place
		{
			public Category Category { get; }

			public Place(Category category)
			{
				this.Category = category;
			}

			public static Place operator +(Place place, int places) => _places[(_places.IndexOf(place) + places) % _places.Count];

			public override string ToString() => $"{_places.IndexOf(this)}";
		}
	}
}