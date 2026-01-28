using System;
using UnityEngine;
using InCheck.Core.Interfaces;
using InCheck.Core.Services;
using InCheck.Game.Configs;
using InCheck.Game.Controllers;
using InCheck.Game.Interfaces;
using InCheck.Game.Models;
using InCheck.Game.Services;

namespace InCheck.Game.Bootstrap
{
    public sealed class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private GameConfig gameConfig;

        private ServiceContainer _serviceContainer;
        private GameController _gameController;

        private void Awake()
        {
            if (gameConfig == null)
            {
                throw new InvalidOperationException("GameConfig is missing.");
            }

            _serviceContainer = new ServiceContainer();
            _serviceContainer.Register<ILogService>(new NullLogService());
            _serviceContainer.Register<IEventBus>(new EventBus());

            var idGenerator = new IncrementingEntityIdGenerator();
            var gameSetupService = new GameSetupService(idGenerator);

            _serviceContainer.Register<IEntityIdGenerator>(idGenerator);
            _serviceContainer.Register<IGameSetupService>(gameSetupService);

            var setupConfig = new GameSetupConfig(
                gameConfig.BoardWidth,
                gameConfig.BoardHeight,
                gameConfig.StartingHealth,
                new Coord(gameConfig.PlayerStartX, gameConfig.PlayerStartY));

            var gameState = gameSetupService.CreateGameState(setupConfig);

            _gameController = new GameController(
                _serviceContainer.Resolve<ILogService>(),
                _serviceContainer.Resolve<IEventBus>(),
                gameState);

            _gameController.Initialize();
        }

        private void OnDestroy()
        {
            _gameController?.Shutdown();
        }
    }
}
