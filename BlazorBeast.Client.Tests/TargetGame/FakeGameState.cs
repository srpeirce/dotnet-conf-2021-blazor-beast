using System;
using System.Threading.Tasks;
using BlazorBeast.Client.TargetGame.State;

namespace BlazorBeast.Client.Tests.TargetGame;

public class FakeGameState : IGameState
{
    public GameStatus GameStatus { get; set; }
    public int Score { get; set; }
    public int TimeLeft { get; set; }
    public int StartCountdown { get; set; }
        
    public bool StartGameHasBeenCalled { get; private set; }
    public bool OnResumeHasBeenCalled { get; private set; }
    public bool OnResetHasBeenCalled { get; private set; }
    public bool OnPauseHasBeenCalled { get; private set; }

    public void OnTargetShot(int targetValue)
    {
        throw new NotImplementedException();
    }

    public Task StartGameAsync()
    {
        StartGameHasBeenCalled = true;
        return Task.CompletedTask;
    }

    public void ResetGame()
    {
        OnResetHasBeenCalled = true;
    }

    public void PauseGame()
    {
        OnPauseHasBeenCalled = true;
    }

    public Task ResumeGame()
    {
        OnResumeHasBeenCalled = true;
        return Task.CompletedTask;
    }
}