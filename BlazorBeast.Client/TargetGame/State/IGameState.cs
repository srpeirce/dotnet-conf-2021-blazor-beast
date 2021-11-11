namespace BlazorBeast.Client.TargetGame.State;

public interface IGameState
{
    GameStatus GameStatus { get; }
    int Score { get; }
    int TimeLeft { get; }
    int StartCountdown { get; }

    void OnTargetShot(int targetValue);
    Task StartGameAsync();
    void ResetGame();
    void PauseGame();
    Task ResumeGame();
}