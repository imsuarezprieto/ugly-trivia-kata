using System;

namespace Trivia
{
	public class Player
	{
		private readonly string name;
		private          int    purse;

		public Player(string name) => this.name = name;

		public          Board.Place Place          { get; set; } = Board.InitialPlace;
		public          bool?       IsInPenaltyBox { get; set; }
		public          bool        HasFullPurse   => purse == 6;
		public override string      ToString()     => name;

		public void Advance(int places)
		{
			Place += places;
			Console.WriteLine($"{this}'s new location is {Place}");
		}

		public void AddCoin()
		{
			purse++;
			Console.WriteLine($"{this} now has {purse} Gold Coins.");
		}

		public void GoToPenaltyBox()
		{
			IsInPenaltyBox = true;
			Console.WriteLine($"{this} was sent to the penalty box");
		}

		public void StayInPenaltyBox()
		{
			IsInPenaltyBox = true;
			Console.WriteLine($"{this} is not getting out of the penalty box");
		}

		public void GetOutPenaltyBox()
		{
			IsInPenaltyBox = false;
			Console.WriteLine($"{this} is getting out of the penalty box");
		}
	}
}