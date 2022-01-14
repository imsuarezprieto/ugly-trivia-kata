using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
	public class Game
    {
        private readonly List<Player> _players = new List<Player>();

        private          int       _currentPlayer;
        private          bool      _isGettingOutOfPenaltyBox;
        private readonly Questions questions = new Questions();

        public void Add(string playerName)
        {
            _players.Add(new Player(playerName));

            Console.WriteLine($"{playerName} was added");
            Console.WriteLine($"They are player number {_players.Count}");
        }

        public void Roll(int roll)
        {
            Console.WriteLine(_players[_currentPlayer] + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (_players[_currentPlayer].IsInPenaltyBox)
            {
                if (roll % 2 != 0)
                {
                    _isGettingOutOfPenaltyBox = true;

                    Console.WriteLine(_players[_currentPlayer] + " is getting out of the penalty box");
                    _players[_currentPlayer].Place = _players[_currentPlayer].Place + roll;
                    if (_players[_currentPlayer].Place > 11) _players[_currentPlayer].Place = _players[_currentPlayer].Place - 12;

                    Console.WriteLine(_players[_currentPlayer]
                            + "'s new location is "
                            + _players[_currentPlayer].Place);
                    Console.WriteLine("The category is " + CurrentCategory());
                    questions.AskQuestion(CurrentCategory());
                }
                else
                {
                    Console.WriteLine(_players[_currentPlayer] + " is not getting out of the penalty box");
                    _isGettingOutOfPenaltyBox = false;
                }
            }
            else
            {
	            _players[_currentPlayer].Place = _players[_currentPlayer].Place + roll;
                if (_players[_currentPlayer].Place > 11) _players[_currentPlayer].Place = _players[_currentPlayer].Place - 12;

                Console.WriteLine(_players[_currentPlayer]
                        + "'s new location is "
                        + _players[_currentPlayer].Place);
                Console.WriteLine("The category is " + CurrentCategory());
                questions.AskQuestion(CurrentCategory());
            }
        }

        public Category CurrentCategory()
        {
	        return _players[_currentPlayer].Place switch
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
            if (_players[_currentPlayer].IsInPenaltyBox)
            {
                if (_isGettingOutOfPenaltyBox)
                {
                    Console.WriteLine("Answer was correct!!!!");
                    _players[_currentPlayer].Purses++;
                    Console.WriteLine(_players[_currentPlayer]
                            + " now has "
                            + _players[_currentPlayer].Purses
                            + " Gold Coins.");

                    var winner = DidPlayerWin();
                    _currentPlayer++;
                    if (_currentPlayer == _players.Count) _currentPlayer = 0;

                    return winner;
                }
                else
                {
                    _currentPlayer++;
                    if (_currentPlayer == _players.Count) _currentPlayer = 0;
                    return true;
                }
            }
            else
            {
                Console.WriteLine("Answer was corrent!!!!");
                _players[_currentPlayer].Purses++;
                Console.WriteLine(_players[_currentPlayer]
                        + " now has "
                        + _players[_currentPlayer].Purses
                        + " Gold Coins.");

                var winner = DidPlayerWin();
                _currentPlayer++;
                if (_currentPlayer == _players.Count) _currentPlayer = 0;

                return winner;
            }
        }

        public bool WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(_players[_currentPlayer] + " was sent to the penalty box");
            _players[_currentPlayer].IsInPenaltyBox = true;

            _currentPlayer++;
            if (_currentPlayer == _players.Count) _currentPlayer = 0;
            return true;
        }


        private bool DidPlayerWin()
        {
            return !(_players[_currentPlayer].Purses == 6);
        }
    }

}
