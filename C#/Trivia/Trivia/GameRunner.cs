using System;

namespace Trivia
{
    public class GameRunner
    {
        private static bool _notAWinner;

        public static void Main(string[] args)
        {
	        RunGame(new Random());
        }

        public static void RunGame(Random random)
        {
	        var aGame = new Game()
					.AddPlayer( name: "Chet")
			        .AddPlayer( name: "Pat")
			        .AddPlayer( name: "Sue");

	        do
	        {
				aGame.NexPlayer();
		        aGame.Roll(random.Next(5) + 1);
				aGame.AskQuestion();

		        if (random.Next(9) == 7)
		        {
			        aGame.WrongAnswer();
		        }
		        else
		        {
			        aGame.CorrectAnswered();
		        }
	        } while (!aGame.HasWinner);
        }
    }
}