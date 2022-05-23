namespace Tennis;

public class Player {
    public string Name { get; }
    public int Score { private set; get; }

    public Player(string name, int score) {
        Name = name;
        Score = score;
    }

    public void IncScore(int value, string name) {
        if (Name == name) {
            Score += value;
        }
    }
}