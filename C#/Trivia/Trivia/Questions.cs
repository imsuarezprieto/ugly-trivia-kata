using System;
using System.Collections.Generic;
using System.Linq;

using Question = System.String;
using Deck = System.Collections.Generic.Queue<string>;

namespace Trivia
{
	public class Questions
	{
		private const int nQuestionsPerCategory = 50;

		private readonly Dictionary<Category, Deck> _questions =
				new Dictionary<Category, Deck>(
						Category.Categories.Select(CategoryQuestions)
				);

		private static KeyValuePair<Category, Deck> CategoryQuestions(Category category) =>
				new KeyValuePair<Category, Deck>(
						category,
						new Deck(
								QuestionDeck(category)
						)
				);

		private static IEnumerable<Question> QuestionDeck(Category category) =>
				Enumerable.Range(0, nQuestionsPerCategory)
						.Select(n => $"{category} Question {n}");

		public void AskQuestion(Category category) =>
				Console.WriteLine(
						_questions[category].Dequeue()
				);
	}
}