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
            string[] scoreNames = {"Love", "Fifteen", "Thirty", "Forty"};
            if (player1Score == player2Score) {
                return ScoreWhenAreEquals(player1Score);
            }

            if (player1Score >= 4 || player2Score >= 4) {
                return ScoreInDouce(player1Score - player2Score);
            }

            return scoreNames[player1Score] + "-" + scoreNames[player2Score];
        }

        private string ScoreWhenAreEquals(int currentScore) {
            switch (currentScore) {
                case 0:
                    return "Love-All";
                case 1:
                    return "Fifteen-All";
                case 2:
                    return "Thirty-All";
                default:
                    return "Deuce";
            }
        }

        private string ScoreInDouce(int minus)
        {
            switch (minus)
            {
                case -1:
                    return "Advantage player2";
                case 1:
                    return "Advantage player1";
                case >= 2:
                    return "Win for player1";
                default:
                    return "Win for player2";
            }
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

