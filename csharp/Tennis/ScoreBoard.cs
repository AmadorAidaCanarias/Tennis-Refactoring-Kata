using System.Collections.Generic;
using System.Linq;

namespace Tennis;

public class ScoreBoard {
    private readonly string[] _scoreNames = new[] { "Love", "Fifteen", "Thirty", "Forty" };
    private readonly Dictionary<int, string> _scoreInDeuce = new() { { -1, "Advantage player2" }, { 0, "Deuce"}, { 1, "Advantage player1" } };

    public string CurrentScore(int player1Score, int player2Score) {
        int difference = (player1Score - player2Score);
        bool playersUnderFour = player1Score < 4 && player2Score < 4;

        if (playersUnderFour) {
            if (difference == 0) {
                return (player1Score < 3) ? _scoreNames[player1Score] + "-All" : "Deuce";
            }
            return _scoreNames[player1Score] + "-" + _scoreNames[player2Score];
        }

        if (_scoreInDeuce.Any(x => x.Key == difference)) {
            return _scoreInDeuce[difference];
        }

        return difference > 0 ? "Win for player1" : "Win for player2";
    }
}