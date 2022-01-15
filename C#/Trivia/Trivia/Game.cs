using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
	public class Game
    {
	    private          Player    currentPlayer;
	    private readonly Players   _players  = new Players();
	    private readonly Questions questions = new Questions();

	    public Game AddPlayer(string name)
        {
            _players.Add(name);
            return this;
        }

        public Game Roll(Die die)
        {
			die.Roll();
            Console.WriteLine($"They have rolled a {die.Result}");

            if (currentPlayer.IsInPenaltyBox != null) 
	            CheckPenaltyBox(die);

            Advance(die.Result);
            return this;
        }

        public Game NexPlayer()
        {
	        this._players.Next();
	        this.currentPlayer = _players.Current;
	        return this;
        }

        private void CheckPenaltyBox(Die die)
        {
	        if (die.IsEven)
		        currentPlayer.StayInPenaltyBox();
	        else
		        currentPlayer.GetOutPenaltyBox();
        }

        public Game AskQuestion()
        {
	        if (currentPlayer.IsInPenaltyBox ?? false) return this;
	        questions.AskQuestion(
			        currentPlayer.Place.Category);
	        return this;
        }

        private void Advance(int roll)
        {
	        if (currentPlayer.IsInPenaltyBox ?? false) return;
	        currentPlayer.Advance(roll);
        }

        public Game CorrectAnswered()
        {
	        if (currentPlayer.IsInPenaltyBox ?? false) return this;
	        Console.WriteLine("Answer was correct!!!!");
	        currentPlayer.AddCoin();
	        return this;
        }

        public Game WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            currentPlayer.GoToPenaltyBox();
            return this;
        }

        public static bool HasWinner(Game game) => game.currentPlayer?.HasFullPurse ?? false;

        public Game SimulateAnswer(Die die) => die.CorrectAnswer ? this : null;
    }

}
