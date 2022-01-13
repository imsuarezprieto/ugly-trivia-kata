using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
	public class Questions
	{
		private const int nQuestionsPerCategory = 50;

		private readonly Dictionary<Category, Queue<string>> _questions =
				new Dictionary<Category, Queue<string>>(
						Category.Categories.Select(CategoryQuestions)
				);

		private static KeyValuePair<Category, Queue<string>> CategoryQuestions(Category category) =>
				new KeyValuePair<Category, Queue<string>>(
						category,
						new Queue<string>(
								QuestionDeck(category)
						)
				);

		private static IEnumerable<string> QuestionDeck(Category category) =>
				Enumerable.Range(0, nQuestionsPerCategory)
						.Select(n => $"{category} Question {n}");

		public void AskQuestion(Category category) =>
				Console.WriteLine(
						_questions[category].Dequeue()
				);
	}
}