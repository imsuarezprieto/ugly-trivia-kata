using System;

namespace Trivia
{
    public static class GameRunner
    {
        public static void Main(string[] args)
        {
	        RunGame(new Random());
        }

        public static void RunGame(Random random)
        {
	        var aGame = new Game();

	        aGame.Add("Chet");
	        aGame.Add("Pat");
	        aGame.Add("Sue");

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