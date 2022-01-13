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
	        var aGame = new Game();

	        aGame.Add("Chet");
	        aGame.Add("Pat");
	        aGame.Add("Sue");

	        do
	        {
		        aGame.Roll(random.Next(5) + 1);

		        if (random.Next(9) == 7)
		        {
			        _notAWinner = aGame.WrongAnswer();
		        }
		        else
		        {
			        _notAWinner = aGame.WasCorrectlyAnswered();
		        }
	        } while (_notAWinner);
        }
    }
}