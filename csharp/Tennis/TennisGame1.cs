namespace Tennis
{
    public class Player
    {
        private string player1Name;

        public Player(string player1Name)
        {
            this.player1Name = player1Name;
        }

        public int Score { set; get; } = 0;
    }

    public class TennisGame1 : ITennisGame
    {
        private const string Player1 = "player1";
        private int m_score2 = 0;
        private string player2Name;
        private readonly Player player1;

        public TennisGame1(string player1Name, string player2Name)
        {
            player1 = new Player(player1Name);
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == Player1)
                player1.Score += 1;
            else
                m_score2 += 1;
        }

        public string GetScore()
        {
            string score = "";
            if (player1.Score == m_score2)
            {
                score = ScoreWhenAreEquals();
            }
            else if (player1.Score >= 4 || m_score2 >= 4)
            {
                score = ScoreWhenAreDifferentsAndGreatterThan4();
            }
            else
            {
                var tempScore = 0;
                for (var i = 1; i < 3; i++)
                {
                    if (i == 1) tempScore = player1.Score;
                    else { score += "-"; tempScore = m_score2; }
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
            }
            return score;
        }

        private string ScoreWhenAreDifferentsAndGreatterThan4()
        {
            string score;
            var minusResult = player1.Score - m_score2;
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

