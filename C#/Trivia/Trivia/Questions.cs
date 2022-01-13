using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
	public class Questions
	{
		private readonly LinkedList<string> _popQuestions     = new LinkedList<string>();
		private readonly LinkedList<string> _scienceQuestions = new LinkedList<string>();
		private readonly LinkedList<string> _sportsQuestions  = new LinkedList<string>();
		private readonly LinkedList<string> _rockQuestions    = new LinkedList<string>();

		public Questions()
		{
			for (var i = 0; i < 50; i++)
			{
				_popQuestions.AddLast("Pop Question " + i);
				_scienceQuestions.AddLast(("Science Question " + i));
				_sportsQuestions.AddLast(("Sports Question "   + i));
				_rockQuestions.AddLast("Rock Question " + i);
			}
		}

		public void AskQuestion(String currentCategory)
		{
			if (currentCategory == "Pop")
			{
				Console.WriteLine(this._popQuestions.First());
				this._popQuestions.RemoveFirst();
			}
			if (currentCategory == "Science")
			{
				Console.WriteLine(this._scienceQuestions.First());
				this._scienceQuestions.RemoveFirst();
			}
			if (currentCategory == "Sports")
			{
				Console.WriteLine(this._sportsQuestions.First());
				this._sportsQuestions.RemoveFirst();
			}
			if (currentCategory == "Rock")
			{
				Console.WriteLine(this._rockQuestions.First());
				this._rockQuestions.RemoveFirst();
			}
		}
	}
}