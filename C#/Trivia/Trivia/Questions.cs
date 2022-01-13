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
			if (currentCategory == Category.Pop)
			{
				Console.WriteLine(this._popQuestions.Dequeue());
			}
			if (currentCategory == Category.Science)
			{
				Console.WriteLine(this._scienceQuestions.Dequeue());
			}
			if (currentCategory == Category.Sports)
			{
				Console.WriteLine(this._sportsQuestions.Dequeue());
			}
			if (currentCategory == Category.Rock)
			{
				Console.WriteLine(this._rockQuestions.Dequeue());
			}
		}
	}
}