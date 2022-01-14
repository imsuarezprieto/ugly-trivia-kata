namespace Trivia
{
	public class Player
	{
		private readonly string _name;

		public Player(string name)
		{
			this._name = name;
		}

		public int  Place          { get; set; } = 0;
		public int  Purse         { get; set; } = 0;
		public bool IsInPenaltyBox { get; set; } = false;

		public override string ToString() => this._name;
	}
}