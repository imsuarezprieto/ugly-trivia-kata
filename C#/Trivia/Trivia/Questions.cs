using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
	public class Questions
	{
		private readonly Queue<string> _popQuestions     = new Queue<string>();
		private readonly Queue<string> _scienceQuestions = new Queue<string>();
		private readonly Queue<string> _sportsQuestions  = new Queue<string>();
		private readonly Queue<string> _rockQuestions    = new Queue<string>();

		public Questions()
		{
			for (var i = 0; i < 50; i++)
			{
				_popQuestions.Enqueue("Pop Question " + i);
				_scienceQuestions.Enqueue(("Science Question " + i));
				_sportsQuestions.Enqueue(("Sports Question "   + i));
				_rockQuestions.Enqueue("Rock Question " + i);
			}
		}

		public void AskQuestion(Category currentCategory)
		{
			switch (currentCategory)
			{
				case Category.Pop:
					Console.WriteLine(this._popQuestions.Dequeue());
					break;
				case Category.Science:
					Console.WriteLine(this._scienceQuestions.Dequeue());
					break;
				case Category.Sports:
					Console.WriteLine(this._sportsQuestions.Dequeue());
					break;
				case Category.Rock:
					Console.WriteLine(this._rockQuestions.Dequeue());
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(currentCategory));
			}
		}
	}
}