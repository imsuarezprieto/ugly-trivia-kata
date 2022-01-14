using System;

namespace Trivia
{
	public class Player
	{
		private readonly string _name;

		public Player(string name)
		{
			this._name = name;
		}

		public Board.Place Place          { get; set; } = Board.InitialPlace;
		public int         Purse          { get; set; } = 0;
		public bool        IsInPenaltyBox { get; set; } = false;

		public override string ToString() => this._name;

		public void Advance(int places)
		{
			this.Place += places;
			Console.WriteLine($"{this}'s new location is {this.Place}");
		}
	}
}