namespace BlazorBeast.Client.TargetGame;

public interface IGameNumber
{
    public int Id { get; }
    public void NextGame();
}