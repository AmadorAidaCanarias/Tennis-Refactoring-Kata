namespace Tennis
{
    public class Player
    {
        public string Name { get; }
        public int Score { private set; get; }

        public Player(string name, int score)
        {
            Name = name;
            Score = score;
        }

        public void IncScore(int value) {
            Score += value;
        }
    }

    public class ScoreBoard
    {
        public string CurrentScore(int player1Score, int player2Score)
        {
            if (player1Score == player2Score)
                return ScoreWhenAreEquals(player1Score);
            if (player1Score >= 4 || player2Score >= 4)
                return ScoreWhenAreDifferentsAndGreatterThan4(player1Score, player2Score);
            return ScoreDefault("", player1Score, player2Score);
        }

        private string ScoreDefault(string score, int player1Score, int player2Score)
        {
            var tempScore = 0;
            for (var i = 1; i < 3; i++)
            {
                if (i == 1) tempScore = player1Score;
                else
                {
                    score += "-";
                    tempScore = player2Score;
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

        private string ScoreWhenAreDifferentsAndGreatterThan4(int player1Score, int player2Score)
        {
            string score;
            var minusResult = player1Score - player2Score;
            if (minusResult == 1) score = "Advantage player1";
            else if (minusResult == -1) score = "Advantage player2";
            else if (minusResult >= 2) score = "Win for player1";
            else score = "Win for player2";
            return score;
        }

        private string ScoreWhenAreEquals(int currentScore)
        {
            string score;
            switch (currentScore)
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

    public class TennisGame1 : ITennisGame
    {
        private readonly Player player1;
        private readonly Player player2;
        private readonly ScoreBoard scoreBoard;

        public TennisGame1(string player1Name, string player2Name)
        {
            player1 = new Player(player1Name, 0);
            player2 = new Player(player2Name, 0);
            scoreBoard = new ScoreBoard();
        }

        public void WonPoint(string playerName)
        {
            if (playerName == player1.Name)
                player1.IncScore(1);
            else
                player2.IncScore(1);
        }

        public string GetScore()
        {
            return scoreBoard.CurrentScore(player1.Score, player2.Score);
        }
    }
}

