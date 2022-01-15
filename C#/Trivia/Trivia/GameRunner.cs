using System;

namespace Trivia
{
	public class GameRunner
	{
		public static void Main(string[] args)
		{
			RunGame(new Random());
		}

		public static void RunGame(Random random)
		{
			Die die = new Die(random);
			new Game()
					.AddPlayer("Chet")
					.AddPlayer("Pat")
					.AddPlayer("Sue")
					.Until(Game.HasWinner, game =>
							_ = game
									.NexPlayer()
									.Roll(die)
									.AskQuestion()
									.SimulateAnswer(die)
									.CorrectAnswered()
							 ?? game.WrongAnswer());
		}
	}
}