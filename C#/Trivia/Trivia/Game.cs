﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
	public class Game
	{
		private readonly bool[] _inPenaltyBox = new bool[6];
		private readonly int[] _places = new int[6];
		private readonly List<string> _players = new List<string>();

		private readonly LinkedList<string> _popQuestions = new LinkedList<string>();
		private readonly int[] _purses = new int[6];
		private readonly LinkedList<string> _rockQuestions = new LinkedList<string>();
		private readonly LinkedList<string> _scienceQuestions = new LinkedList<string>();
		private readonly LinkedList<string> _sportsQuestions = new LinkedList<string>();

		private int _currentPlayer;
		private bool _isGettingOutOfPenaltyBox;

		public Game()
		{
			for (var i = 0; i < 50; i++)
			{
				_popQuestions.AddLast($"Pop Question {i}");
				_scienceQuestions.AddLast($"Science Question {i}");
				_sportsQuestions.AddLast($"Sports Question {i}");
				_rockQuestions.AddLast($"Rock Question {i}");
			}
		}

		public void Add(string playerName)
		{
			_players.Add(playerName);
			_places[HowManyPlayers()] = 0;
			_purses[HowManyPlayers()] = 0;
			_inPenaltyBox[HowManyPlayers()] = false;

			Console.WriteLine($"{playerName} was added");
			Console.WriteLine($"They are player number {_players.Count}");
		}

		private int HowManyPlayers()
		{
			return _players.Count;
		}

		public void Roll(int roll)
		{
			Console.WriteLine($"{_players[_currentPlayer]} is the current player");
			Console.WriteLine($"They have rolled a {roll}");

			if (_inPenaltyBox[_currentPlayer])
			{
				if (RollEven(roll))
				{
					_isGettingOutOfPenaltyBox = true;

					Console.WriteLine($"{_players[_currentPlayer]} is getting out of the penalty box");
					_places[_currentPlayer] = _places[_currentPlayer] + roll;
					if (_places[_currentPlayer] > 11) _places[_currentPlayer] = _places[_currentPlayer] - 12;

					Console.WriteLine($"{_players[_currentPlayer]}'s new location is {_places[_currentPlayer]}");
					Console.WriteLine($"The category is {CurrentCategory()}");
					AskQuestion();
				}
				else
				{
					Console.WriteLine($"{_players[_currentPlayer]} is not getting out of the penalty box");
					_isGettingOutOfPenaltyBox = false;
				}
			}
			else
			{
				_places[_currentPlayer] = _places[_currentPlayer] + roll;
				if (_places[_currentPlayer] > 11) _places[_currentPlayer] = _places[_currentPlayer] - 12;

				Console.WriteLine($"{_players[_currentPlayer]}'s new location is {_places[_currentPlayer]}");
				Console.WriteLine($"The category is {CurrentCategory()}");
				AskQuestion();
			}
		}

		private bool RollEven(int roll)
		{
			return roll % 2 != 0;
		}

		private void AskQuestion()
		{
			if (CurrentCategory() == "Pop")
			{
				Console.WriteLine(_popQuestions.First());
				_popQuestions.RemoveFirst();
			}

			if (CurrentCategory() == "Science")
			{
				Console.WriteLine(_scienceQuestions.First());
				_scienceQuestions.RemoveFirst();
			}

			if (CurrentCategory() == "Sports")
			{
				Console.WriteLine(_sportsQuestions.First());
				_sportsQuestions.RemoveFirst();
			}

			if (CurrentCategory() == "Rock")
			{
				Console.WriteLine(_rockQuestions.First());
				_rockQuestions.RemoveFirst();
			}
		}

		private string CurrentCategory() =>
				_places[_currentPlayer] switch
				{
						0 => "Pop",
						4 => "Pop",
						8 => "Pop",
						1 => "Science",
						5 => "Science",
						9 => "Science",
						2 => "Sports",
						6 => "Sports",
						10 => "Sports",
						_ => "Rock"
				};

		public bool WasCorrectlyAnswered()
		{
			if (!_inPenaltyBox[_currentPlayer])
			{
				{
					Console.WriteLine("Answer was corrent!!!!");
					_purses[_currentPlayer]++;
					Console.WriteLine($"{_players[_currentPlayer]} now has {_purses[_currentPlayer]} Gold Coins.");

					var winner = DidPlayerWin();
					_currentPlayer++;
					if (_currentPlayer == _players.Count) _currentPlayer = 0;

					return winner;
				}
			}
			if (_isGettingOutOfPenaltyBox)
			{
				Console.WriteLine("Answer was correct!!!!");
				_purses[_currentPlayer]++;
				Console.WriteLine($"{_players[_currentPlayer]} now has {_purses[_currentPlayer]} Gold Coins.");

				var winner = DidPlayerWin();
				_currentPlayer++;
				if (_currentPlayer == _players.Count) _currentPlayer = 0;

				return winner;
			}

			_currentPlayer++;
			if (_currentPlayer == _players.Count) _currentPlayer = 0;
			return true;
		}

		public bool WrongAnswer()
		{
			Console.WriteLine("Question was incorrectly answered");
			Console.WriteLine($"{_players[_currentPlayer]} was sent to the penalty box");
			_inPenaltyBox[_currentPlayer] = true;

			_currentPlayer++;
			if (_currentPlayer == _players.Count) _currentPlayer = 0;
			return true;
		}


		private bool DidPlayerWin()
		{
			return _purses[_currentPlayer] != 6;
		}
	}
}