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

        public void Roll(Die die)
        {
			die.Roll();
            Console.WriteLine($"They have rolled a {die.Result}");

            if (currentPlayer.IsInPenaltyBox != null) 
	            CheckPenaltyBox(die);

            Advance(die.Result);
        }

        public void NexPlayer()
        {
	        this._players.Next();
	        this.currentPlayer = _players.Current;
        }

        private void CheckPenaltyBox(Die die)
        {
	        if (die.IsEven)
		        currentPlayer.StayInPenaltyBox();
	        else
		        currentPlayer.GetOutPenaltyBox();
        }

        public void AskQuestion()
        {
	        if (currentPlayer.IsInPenaltyBox ?? false) return;
	        questions.AskQuestion(
			        currentPlayer.Place.Category);
        }

        private void Advance(int roll)
        {
	        if (currentPlayer.IsInPenaltyBox ?? false) return;
	        currentPlayer.Advance(roll);
        }

        public void CorrectAnswered()
        {
	        if (currentPlayer.IsInPenaltyBox ?? false) return;
	        Console.WriteLine("Answer was correct!!!!");
	        currentPlayer.AddCoin();
        }

        public void WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            currentPlayer.GoToPenaltyBox();
        }

        public static bool HasWinner(Game game) => game.currentPlayer?.HasFullPurse ?? false;
	}

}
