using System;

namespace Trivia
{
	public class Game
    {
	    private          Player    currentPlayer;
	    private readonly Players   players  = new Players();
	    private readonly Questions questions = new Questions();

	    public void Add(string playerName)
        {
            players.Add(playerName);
        }

        public void Roll(int roll)
        {
            Console.WriteLine("They have rolled a " + roll);

            if (currentPlayer.IsInPenaltyBox != null) 
	            CheckPenaltyBox(roll);

            Advance(roll);
        }

        public void NexPlayer()
        {
	        this.players.Next();
	        this.currentPlayer = players.Current;
        }

        private void CheckPenaltyBox(int roll)
        {
	        if (roll % 2 == 0)
		        currentPlayer.StayInPenaltyBox();
	        else
		        currentPlayer.GetOutPenaltyBox();
        }

        public void AskQuestion()
        {
	        if (currentPlayer.IsInPenaltyBox ?? false) return;
	        questions.AskQuestion(
			        currentPlayer.Place.Category);
        }

        private void Advance(int roll)
        {
	        if (currentPlayer.IsInPenaltyBox ?? false) return;
	        currentPlayer.Advance(roll);
        }

        public void CorrectAnswered()
        {
	        if (currentPlayer.IsInPenaltyBox ?? false) return;
	        Console.WriteLine("Answer was correct!!!!");
	        currentPlayer.AddCoin();
        }

        public void WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            currentPlayer.GoToPenaltyBox();
        }

        public bool HasWinner => currentPlayer.HasFullPurse;
	}

}
