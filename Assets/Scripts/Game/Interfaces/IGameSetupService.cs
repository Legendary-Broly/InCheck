using InCheck.Game.Models;

namespace InCheck.Game.Interfaces
{
    public interface IGameSetupService
    {
        GameState CreateGameState(GameSetupConfig config);
    }
}
