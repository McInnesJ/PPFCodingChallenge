using System.Reflection.Metadata;

namespace Tennis.Game
{
    public class TennisGame : ITennisGame
    {
        private const string Love = "Love";
        private const string Fifteen = "Fifteen";
        private const string Thirty = "Thirty";
        private const string Deuce = "Deuce";

        private const string All = "All";
        private const string Advantage = "Advantage ";
        private const string Win = "Win for ";
        
        private int serversScore = 0;
        private int receiversScore = 0;

        private readonly string servingPlayer;
        private readonly string receivingPlayer;

        public TennisGame(string servingPlayer, string receivingPlayer)
        {
            this.servingPlayer = servingPlayer;
            this.receivingPlayer = receivingPlayer;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == this.servingPlayer)
            {
                this.serversScore++;
                return;
            }

            if (playerName == this.receivingPlayer)
            {
                this.receiversScore++;
                return;
            }

            throw new ArgumentException($"Player {playerName} is not part of this match");
        }

        public string GetScore()
        {
            if (this.serversScore == this.receiversScore)
            {
                return GetEqualScoreString();
            }

            if (this.serversScore <= 3 && this.receiversScore <= 3)
            {
                return GetStandardScoreString();
            }

            if (this.serversScore == this.receiversScore + 1)
            {
                return Advantage + this.servingPlayer;
            }

            if (this.serversScore >= this.receiversScore + 2)
            {
                return Win + this.servingPlayer;
            }

            if (this.receiversScore == this.serversScore + 1)
            {
                return Advantage + this.receivingPlayer;
            }

            if (this.receiversScore >= this.serversScore + 2)
            {
                return Win + this.receivingPlayer;
            }

            throw new InvalidOperationException("Score in unexpected state, cannot proceed");
        }

        private string GetEqualScoreString()
        {
            string score;
            switch (this.serversScore)
            {
                case 0:
                    score = $"{Love}-{All}";
                    break;
                case 1:
                    score = $"{Fifteen}-{All}";
                    break;
                case 2:
                    score = $"{Thirty}-{All}";
                    break;
                default:
                    score = Deuce;
                    break;

            }

            return score;
        }

        private string GetStandardScoreString()
        {
            string score = "";
            
            switch (this.serversScore)
            {
                case 0:
                    score += "Love";
                    break;
                case 1:
                    score += "Fifteen";
                    break;
                case 2:
                    score += "Thirty";
                    break;
                case 3:
                    score += "Forty";
                    break;
            }

            score += "-";

            switch (this.receiversScore)
            {
                case 0:
                    score += "Love";
                    break;
                case 1:
                    score += "Fifteen";
                    break;
                case 2:
                    score += "Thirty";
                    break;
                case 3:
                    score += "Forty";
                    break;
            }

            return score;
        }
    }
}
