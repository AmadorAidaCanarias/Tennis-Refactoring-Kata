namespace Tennis
{
    public class Player
    {
        public string Name;

        public Player(string name)
        {
            Name = name;
        }

        public int Score { set; get; } = 0;
    }

    public class TennisGame1 : ITennisGame
    {
        private const string Player1Name = "player1";
        private readonly Player player1;
        private readonly Player player2;

        public TennisGame1(string player1Name, string player2Name)
        {
            player1 = new Player(player1Name);
            player2 = new Player(player2Name);
        }

        public void WonPoint(string playerName)
        {
            if (playerName == Player1Name)
                player1.Score += 1;
            else
                player2.Score += 1;
        }

        public string GetScore()
        {
            if (player1.Score == player2.Score)
                return ScoreWhenAreEquals();
            if (player1.Score >= 4 || player2.Score >= 4)
                return ScoreWhenAreDifferentsAndGreatterThan4();
            return ScoreDefault("");
        }

        private string ScoreDefault(string score)
        {
            var tempScore = 0;
            for (var i = 1; i < 3; i++)
            {
                if (i == 1) tempScore = player1.Score;
                else
                {
                    score += "-";
                    tempScore = player2.Score;
                }

                switch (tempScore)
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
            }

            return score;
        }

        private string ScoreWhenAreDifferentsAndGreatterThan4()
        {
            string score;
            var minusResult = player1.Score - player2.Score;
            if (minusResult == 1) score = "Advantage player1";
            else if (minusResult == -1) score = "Advantage player2";
            else if (minusResult >= 2) score = "Win for player1";
            else score = "Win for player2";
            return score;
        }

        private string ScoreWhenAreEquals()
        {
            string score;
            switch (player1.Score)
            {
                case 0:
                    score = "Love-All";
                    break;
                case 1:
                    score = "Fifteen-All";
                    break;
                case 2:
                    score = "Thirty-All";
                    break;
                default:
                    score = "Deuce";
                    break;
            }

            return score;
        }
    }
}

