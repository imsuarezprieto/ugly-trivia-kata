using System.Collections.Generic;

namespace Trivia
{
	public class Questions
	{
		public readonly LinkedList<string> _popQuestions     = new LinkedList<string>();
		public readonly LinkedList<string> _scienceQuestions = new LinkedList<string>();
		public readonly LinkedList<string> _sportsQuestions  = new LinkedList<string>();
		public readonly LinkedList<string> _rockQuestions    = new LinkedList<string>();

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
	}
}