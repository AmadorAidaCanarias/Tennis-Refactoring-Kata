using System.Collections.Generic;
using System.Linq;

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
        private readonly string[] _scoreNames = new[] {"Love", "Fifteen", "Thirty", "Forty"};
        private readonly Dictionary<int, string> _scoreAdvantage = new() { { -1, "Advantage player2" }, { 1, "Advantage player1" } };

        public string CurrentScore(int player1Score, int player2Score)
        {
            int difference = (player1Score - player2Score);

            if (difference == 0)
            {
                return (player1Score < 3) ? _scoreNames[player1Score] + "-All" : "Deuce";
            }

            if (player1Score <= 3 & player2Score <= 3) { 
                return _scoreNames[player1Score] + "-" + _scoreNames[player2Score];
            }

            if (_scoreAdvantage.Any(x => x.Key == difference)) {
                return _scoreAdvantage[difference];
            }

            switch (difference) {
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

