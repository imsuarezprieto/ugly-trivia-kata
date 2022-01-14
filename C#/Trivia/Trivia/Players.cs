using System;
using System.Collections.Generic;

namespace Trivia
{
	public class Players
	{
		private readonly List<Player> _players = new List<Player>();
		private          int          current  = 2;

		public Player Current => this._players[current];

		public void Add(string playerName)
		{
			this._players.Add(new Player(playerName));

			Console.WriteLine($"{playerName} was added");
			Console.WriteLine($"They are player number {_players.Count}");
		}

		public void Next()
		{
			this.current = ++this.current % this._players.Count;
			Console.WriteLine($"{this.Current} is the current player");
		}
	}
}