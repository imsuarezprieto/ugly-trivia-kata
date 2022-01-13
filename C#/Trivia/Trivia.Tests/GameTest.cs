using System;
using System.IO;
using System.Linq;
using Xunit;

namespace Trivia.Tests
{
	public class GameTest
	{
		[Fact]
		public void GenerateGoldenMaster()
		{
			const string golderMasterFolder = @"../../../../GoldenMaster";
			Directory.CreateDirectory(golderMasterFolder);
			foreach (int randomSeed in Enumerable.Range(0, 4000))
			{
				using StreamWriter output =
						new StreamWriter(
								new FileStream(
										$@"{golderMasterFolder}/Output-{randomSeed:0000}.txt",
										FileMode.Create
								)
						);
				Console.SetOut(output);
				GameRunner.RunGame(
						new Random(randomSeed)
				);
			}
		}
	}
}