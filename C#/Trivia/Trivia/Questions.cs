using System;
using System.Collections.Generic;
using System.Linq;
using Question = System.String;
using QuestionDeck = System.Collections.Generic.Queue<string>;

namespace Trivia
{
	public class Questions
	{
		private const int nQuestionsPerCategory = 50;

		private readonly Dictionary<Category, QuestionDeck> _questions =
				new Dictionary<Category, QuestionDeck>(
						Category.Categories.Select(
								CategoryQuestions
						)
				);

		private static KeyValuePair<Category, QuestionDeck> CategoryQuestions(Category category) =>
				new KeyValuePair<Category, QuestionDeck>(
						category,
						new QuestionDeck(
								QuestionPerCategory(category)
						)
				);

		private static IEnumerable<string> QuestionPerCategory(Category category) =>
				Enumerable.Range(0, nQuestionsPerCategory)
						.Select(n =>
								$"{category} Question {n}"
						);

		public void AskQuestion(Category category) =>
				Console.WriteLine(
						$"The category is {category}\r\n{_questions[category].Dequeue()}"
				);
	}
}