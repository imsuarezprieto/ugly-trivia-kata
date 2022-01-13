using System;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace Trivia.Tests
{
	public class GameTest
	{
		[Fact(Skip = "Just initial generation")]
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

		[Fact]
		public void VerifyGoldenMaster()
		{
			const string golderMasterFolder = @"../../../../GoldenMaster";
			foreach (int randomSeed in Enumerable.Range(0, 4000))
			{
				StringBuilder output = new StringBuilder();
				Console.SetOut(
						new StringWriter(output)
				);
				GameRunner.RunGame(
						new Random(randomSeed)
				);
				Assert.Equal(
						File.ReadAllText($@"{golderMasterFolder}/Output-{randomSeed:0000}.txt"),
						output.ToString());
			}
		}
	}
}