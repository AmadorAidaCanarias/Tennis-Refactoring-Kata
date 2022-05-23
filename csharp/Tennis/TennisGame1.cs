namespace Tennis {
    public class TennisGame1 : ITennisGame {
        private readonly Player player1;
        private readonly Player player2;
        private readonly ScoreBoard scoreBoard;

        public TennisGame1(string player1Name, string player2Name) {
            player1 = new Player(player1Name, 0);
            player2 = new Player(player2Name, 0);
            scoreBoard = new ScoreBoard();
        }

        public void WonPoint(string playerName)
        {
            player1.IncScore(1, playerName);
            player2.IncScore(1, playerName);
        }

        public string GetScore() {
            return scoreBoard.CurrentScore(player1.Score, player2.Score);
        }
    }
}

