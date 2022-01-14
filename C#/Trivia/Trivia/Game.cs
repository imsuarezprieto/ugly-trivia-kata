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
                    _players.Current.Place = _players.Current.Place + roll;
                    if (_players.Current.Place > 11) _players.Current.Place = _players.Current.Place - 12;

                    Console.WriteLine(_players.Current
                            + "'s new location is "
                            + _players.Current.Place);
                    Console.WriteLine("The category is " + CurrentCategory());
                    questions.AskQuestion(CurrentCategory());
                }
                else
                {
                    Console.WriteLine(_players.Current + " is not getting out of the penalty box");
                    _isGettingOutOfPenaltyBox = false;
                }
            }
            else
            {
	            _players.Current.Place = _players.Current.Place + roll;
                if (_players.Current.Place > 11) _players.Current.Place = _players.Current.Place - 12;

                Console.WriteLine(_players.Current
                        + "'s new location is "
                        + _players.Current.Place);
                Console.WriteLine("The category is " + CurrentCategory());
                questions.AskQuestion(CurrentCategory());
            }
        }

        public Category CurrentCategory()
        {
	        return _players.Current.Place switch
	        {
			        0  => Category.Pop,
			        4  => Category.Pop,
			        8  => Category.Pop,
			        1  => Category.Science,
			        5  => Category.Science,
			        9  => Category.Science,
			        2  => Category.Sports,
			        6  => Category.Sports,
			        10 => Category.Sports,
			        _  => Category.Rock
	        };
        }

        public bool WasCorrectlyAnswered()
        {
            if (_players.Current.IsInPenaltyBox)
            {
                if (_isGettingOutOfPenaltyBox)
                {
                    Console.WriteLine("Answer was correct!!!!");
                    _players.Current.Purses++;
                    Console.WriteLine(_players.Current
                            + " now has "
                            + _players.Current.Purses
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
                _players.Current.Purses++;
                Console.WriteLine(_players.Current
                        + " now has "
                        + _players.Current.Purses
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
            return !(_players.Current.Purses == 6);
        }
    }

}
