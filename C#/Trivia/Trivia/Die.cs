﻿using System;

namespace Trivia
{
	public class Die
	{
		private readonly Random random;

		public int Result { get; private set; }

		public Die(Random random)
		{
			this.random = random;
		}

		public void Roll()
		{
			Result = random.Next(1, 6);
		}
	}
}