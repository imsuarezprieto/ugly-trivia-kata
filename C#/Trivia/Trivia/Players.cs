using System;
using System.Collections.Generic;

namespace Trivia
{
	public class Players
	{
		private readonly List<Player> players = new List<Player>();
		private          int          current  = 2;

		public Player Current => this.players[current];

		public void Add(string playerName)
		{
			this.players.Add(new Player(playerName));

			Console.WriteLine($"{playerName} was added");
			Console.WriteLine($"They are player number {players.Count}");
		}

		public void Next()
		{
			this.current = ++this.current % this.players.Count;
			Console.WriteLine($"{this.Current} is the current player");
		}
	}
}