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
		public bool?        IsInPenaltyBox { get; set; }

		public override string ToString() => this._name;

		public void Advance(int places)
		{
			this.Place += places;
			Console.WriteLine($"{this}'s new location is {this.Place}");
		}

		public bool HasFullPurse => this.Purse == 6;

		public void AddCoin()
		{
			this.Purse++;
			Console.WriteLine($"{this} now has {this.Purse} Gold Coins.");
		}

		public void GoToPenaltyBox()
		{
			this.IsInPenaltyBox = true;
			Console.WriteLine($"{this} was sent to the penalty box");
		}

		public void StayInPenaltyBox()
		{
			this.IsInPenaltyBox = true;
			Console.WriteLine($"{this} is not getting out of the penalty box");
		}

		public void GetOutPenaltyBox()
		{
			this.IsInPenaltyBox = false;
			Console.WriteLine($"{this} is getting out of the penalty box");
		}
	}
}