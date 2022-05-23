namespace Tennis;

public class Player {
    private string Name { get; }
    public int Score { private set; get; }

    public Player(string name, int score) {
        Name = name;
        Score = score;
    }

    public void IncScore(string name) {
        if (Name == name) {
            ++Score;
        }
    }
}