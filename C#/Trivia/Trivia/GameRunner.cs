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
	        new Game()
			        .AddPlayer(name: "Chet")
			        .AddPlayer(name: "Pat")
			        .AddPlayer(name: "Sue")
			        .Until(Game.HasWinner, game =>
			        {
				        game.NexPlayer();
				        game.Roll(random.Next(5) + 1);
				        game.AskQuestion();

				        if (random.Next(9) == 7)
				        {
					        game.WrongAnswer();
				        }
				        else
				        {
					        game.CorrectAnswered();
				        }
					});
        }
    }
}