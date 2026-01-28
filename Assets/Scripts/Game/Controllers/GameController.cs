using InCheck.Core.Interfaces;
using InCheck.Game.Events;
using InCheck.Game.Models;

namespace InCheck.Game.Controllers
{
    public sealed class GameController : IController
    {
        private readonly ILogService _logService;
        private readonly IEventBus _eventBus;
        private readonly GameState _gameState;

        public GameController(ILogService logService, IEventBus eventBus, GameState gameState)
        {
            _logService = logService;
            _eventBus = eventBus;
            _gameState = gameState;
        }

        public void Initialize()
        {
            _logService.Log("GameController initialized.");
            _eventBus.Publish(new GameStartedEvent(_gameState));
        }

        public void Shutdown()
        {
            _logService.Log("GameController shutdown.");
        }
    }
}
