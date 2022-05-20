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

            if (player1Score <= 3 & player2Score <= 3) { 
                string score = scoreNames[player1Score] + "-" + ( (player1Score == player2Score) ? "All" : scoreNames[player2Score] );
                return (score == "Forty-All") ? "Deuce" : score;
            }

            return ScoreInDouce(player1Score - player2Score);
        }

        private string ScoreInDouce(int minus)
        {
            switch (minus)
            {
                case 0: return "Deuce";
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

