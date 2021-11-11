using BlazorBeast.Shared.HighScores;

namespace BlazorBeast.Server;

public static class HighScoresApi
{
    private static readonly List<HighScore> HighScores = new()
    {
        new HighScore(5080, "@BethMassi"),
        new HighScore(3680, "@csharpfritz"),
        new HighScore(3600, "@jongalloway"),
        new HighScore(3600, "@captainsafia"),
        new HighScore(3080, "@buhakmeh"),
        new HighScore(2400, "@DamianEdwards"),
        new HighScore(2320, "@stevensanderson"),
        new HighScore(2180, "@egilhansen"),
        new HighScore(2140, "@maartenballiauw"),
        new HighScore(2100, "@JOSH_DALEK"),
        new HighScore(1480, "@davidfowl"),
        new HighScore(1460, "@shanselman"),
        new HighScore(1440, "@buhakmeh"),
        new HighScore(1120, "@srpeirce"),
        new HighScore(1080, "@coolcsh"),
    };
    
    public static WebApplication MapHighScoresApi(this WebApplication app)
    {
        app.MapGet("api/high-scores", () => HighScores.OrderByDescending(s => s.Score));
        app.MapGet("api/high-scores/slow", async () =>
        {
            await Task.Delay(1000);
            return HighScores.OrderByDescending(s => s.Score);
        });
        
        app.MapGet("api/high-scores/error", async () =>
        {
            await Task.Delay(500);
            throw new Exception("BOOOOOOOOOOOOMMMMM!!!!");
        });
        return app;
    }
}