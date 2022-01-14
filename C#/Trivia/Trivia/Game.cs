using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
	public class Game
    {
	    private          bool    _isGettingOutOfPenaltyBox;

	    private readonly Players   _players  = new Players();
	    private readonly Questions questions = new Questions();

        public void Add(string playerName)
        {
            _players.Add(playerName);
        }

        public void Roll(int roll)
        {
            Console.WriteLine(_players.Current + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (_players.Current.IsInPenaltyBox)
            {
                if (roll % 2 != 0)
                {
                    _isGettingOutOfPenaltyBox = true;

                    Console.WriteLine(_players.Current + " is getting out of the penalty box");

					_players.Current.Advance(roll);

                    Console.WriteLine(_players.Current
                            + "'s new location is "
                            + _players.Current.Place);
                    questions.AskQuestion(
		                    _players.Current.Place.Category);
                }
                else
                {
                    Console.WriteLine(_players.Current + " is not getting out of the penalty box");
                    _isGettingOutOfPenaltyBox = false;
                }
            }
            else
            {
				_players.Current.Advance(roll);

				Console.WriteLine(_players.Current
                        + "'s new location is "
                        + _players.Current.Place);
                questions.AskQuestion(
		                _players.Current.Place.Category);
            }
        }

        public bool WasCorrectlyAnswered()
        {
            if (_players.Current.IsInPenaltyBox)
            {
                if (_isGettingOutOfPenaltyBox)
                {
                    Console.WriteLine("Answer was correct!!!!");
                    _players.Current.Purse++;
                    Console.WriteLine(_players.Current
                            + " now has "
                            + _players.Current.Purse
                            + " Gold Coins.");

                    var winner = DidPlayerWin();
                    this._players.Next();

                    return winner;
                }
                else
                {
                    this._players.Next();
                    return true;
                }
            }
            else
            {
                Console.WriteLine("Answer was corrent!!!!");
                _players.Current.Purse++;
                Console.WriteLine(_players.Current
                        + " now has "
                        + _players.Current.Purse
                        + " Gold Coins.");

                var winner = DidPlayerWin();
                this._players.Next();

                return winner;
            }
        }

        public bool WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(_players.Current + " was sent to the penalty box");
            _players.Current.IsInPenaltyBox = true;

            this._players.Next();
            return true;
        }


        private bool DidPlayerWin()
        {
            return !(_players.Current.Purse == 6);
        }
    }

}
