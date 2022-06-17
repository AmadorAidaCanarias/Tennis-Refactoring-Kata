namespace Tennis;

public class Player {
    private string Name { get; }
    public int Score { private set; get; }
    private readonly string[] _scoreNames = new[] { "Love", "Fifteen", "Thirty", "Forty" };

    public Player(string name) {
        Name = name;
        Score = 0;
    }

    public void Register() {
        ++Score;
    }

    public bool DidYouWinPoint(string name) => Name.Equals(name);
    public bool ScoreUnderOrEqualForty() => Score < 4;
    public bool ScoreAboveOrEqualForty() => Score >= 3;
    public string PrettyScore() {
        if (Score <= _scoreNames.Length) { 
            return _scoreNames[Score];
        }

        return "";
    }
}