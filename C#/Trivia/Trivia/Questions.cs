using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
	public class Questions
	{
		private readonly Dictionary<Category, Queue<string>> _questions =
				new Dictionary<Category, Queue<string>>(
						Category.Categories
								.Select(category =>
										new KeyValuePair<Category, Queue<string>>(
												category,
												new Queue<string>(
														Enumerable.Range(0, 50)
																.Select(n => $"{category} Question {n}")
												)
										)
								)
				);

		public void AskQuestion(Category category) =>
				Console.WriteLine(
						_questions[category].Dequeue()
				);
	}
}