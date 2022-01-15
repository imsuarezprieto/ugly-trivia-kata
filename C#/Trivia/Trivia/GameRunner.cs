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
			        .AddPlayer(name: "Chet")
			        .AddPlayer(name: "Pat")
			        .AddPlayer(name: "Sue")
			        .Until(Game.HasWinner, game =>
			        {
				        game.NexPlayer();
				        game.Roll(die);
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