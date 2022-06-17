using System.Collections.Generic;

namespace Tennis;

public class ScoreBoard {
    private readonly Dictionary<int, string> _scoreInDeuce = new() { { -1, "Advantage player2" }, { 0, "Deuce" }, { 1, "Advantage player1" } };

    public string CurrentScore(Player player1, Player player2) {
        if (AreTwoScorePlayersUnderOrEqualForty(player1, player2)) {
            return ScoreWhenTwoPlayersUnderForty(player1, player2);
        }

        return ScoreWhenAnyPlayerAboveForty(player1, player2);
    }

    private static bool AreTwoScorePlayersUnderOrEqualForty(Player player1, Player player2) {
        return player1.ScoreUnderOrEqualForty() && player2.ScoreUnderOrEqualForty();
    }

    private string ScoreWhenAnyPlayerAboveForty(Player player1, Player player2) {
        if (PlayersInDeuce(player1, player2))
            return ScoreInDeuce(player1, player2);

        return WinnerScore(player1, player2);
    }

    private static string WinnerScore(Player player1, Player player2) {
        var difference = player1.Score - player2.Score;
        return $"Win for player{(difference > 0 ? 1 : 2)}";
    }

    private string ScoreWhenTwoPlayersUnderForty(Player player1, Player player2) {
        if (PlayersInDeuce(player1, player2)) {
            return ScoreInDeuce(player1, player2);
        }

        return ScorePlayers(player1, player2);
    }

    private static string ScorePlayers(Player player1, Player player2) {
        var firstScoreName = player1.PrettyScore();
        var secondScoreName = player2.PrettyScore().Replace(firstScoreName, "All");
        return firstScoreName + "-" + secondScoreName;
    }

    private string ScoreInDeuce(Player player1, Player player2) {
        return _scoreInDeuce[(player1.Score - player2.Score)];
    }

    private static bool PlayersInDeuce(Player player1, Player player2) {
        var player2NotWin = (player1.Score - player2.Score) > -2;
        var player1NotWin = (player1.Score - player2.Score) < 2;
        var scoresAboveOrEqualForty = player1.ScoreAboveOrEqualForty() && player2.ScoreAboveOrEqualForty();
        return player2NotWin && player1NotWin && scoresAboveOrEqualForty;
    }
}