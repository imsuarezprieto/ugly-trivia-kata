using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
	public class Game
    {
	    private readonly Players   _players  = new Players();
	    private readonly Questions questions = new Questions();

        public void Add(string playerName)
        {
            _players.Add(playerName);
        }

        public void Roll(int roll)
        {
	        this._players.Next();
            Console.WriteLine("They have rolled a " + roll);

            if (_players.Current.IsInPenaltyBox != null)
            {
	            if (roll % 2 == 0)
	            {
		          _players.Current.StayInPenaltyBox();
		          return;
	            }
	            else
	            {
		            _players.Current.GetOutPenaltyBox();
	            }
            }

	        _players.Current.Advance(roll);
	        questions.AskQuestion(
		                _players.Current.Place.Category);
            
        }

        public void WasCorrectlyAnswered()
        {
            if (!_players.Current.IsInPenaltyBox ?? true)
            {
	            Console.WriteLine("Answer was correct!!!!");
                _players.Current.AddCoin();
            }
        }

        public void WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            _players.Current.GoToPenaltyBox();
        }


		public bool HasWinner => _players.Current.HasFullPurse;
	}

}
