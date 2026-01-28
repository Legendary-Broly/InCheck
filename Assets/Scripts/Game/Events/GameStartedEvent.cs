using InCheck.Game.Models;

namespace InCheck.Game.Events
{
    public readonly struct GameStartedEvent
    {
        public GameState GameState { get; }

        public GameStartedEvent(GameState gameState)
        {
            GameState = gameState;
        }
    }
}
