namespace Tennis {
    public class TennisGame1 : ITennisGame {
        private readonly Player player1;
        private readonly Player player2;
        private readonly ScoreBoard scoreBoard;

        public TennisGame1(string player1Name, string player2Name) {
            player1 = new Player(player1Name);
            player2 = new Player(player2Name);
            scoreBoard = new ScoreBoard();
        }

        public void WonPoint(string playerName) {
            if (player1.DidYouWinPoint(playerName)) {
                player1.Register();
            }
            else {
                player2.Register();
            }
        }

        public string GetScore() {
            return scoreBoard.CurrentScore(player1, player2);
        }
    }
}

