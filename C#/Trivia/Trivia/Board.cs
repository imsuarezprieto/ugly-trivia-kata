using System.Collections.Generic;

namespace Trivia
{
	public static class Board
	{
		private static readonly IList<Place> places = new List<Place>
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
				new Place(Category.Rock)
		};

		public static Place InitialPlace => places[0];

		public class Place
		{
			public Place(Category category)
			{
				Category = category;
			}

			public Category Category { get; }

			public static Place operator +(Place place, int places)
			{
				return Board.places[(Board.places.IndexOf(place) + places) % Board.places.Count];
			}

			public override string ToString()
			{
				return $"{places.IndexOf(this)}";
			}
		}
	}
}