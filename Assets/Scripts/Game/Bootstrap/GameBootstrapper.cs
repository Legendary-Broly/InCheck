using System;
using UnityEngine;
using InCheck.Core.Interfaces;
using InCheck.Core.Services;
using InCheck.Game.Configs;
using InCheck.Game.Controllers;
using InCheck.Game.Models;

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

            var gameState = new GameState(gameConfig.StartingHealth, gameConfig.ActionPointsPerTurn);

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
