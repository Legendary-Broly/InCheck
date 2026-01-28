using System;
using System.Collections.Generic;
using InCheck.Game.Interfaces;
using InCheck.Game.Models;

namespace InCheck.Game.Services
{
    public sealed class GameSetupService : IGameSetupService
    {
        private readonly IEntityIdGenerator _idGenerator;

        public GameSetupService(IEntityIdGenerator idGenerator)
        {
            _idGenerator = idGenerator ?? throw new ArgumentNullException(nameof(idGenerator));
        }

        public GameState CreateGameState(GameSetupConfig config)
        {
            if (config.Width <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(config.Width), "Width must be greater than zero.");
            }

            if (config.Height <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(config.Height), "Height must be greater than zero.");
            }

            if (config.StartingHealth <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(config.StartingHealth), "StartingHealth must be greater than zero.");
            }

            if (!config.PlayerStart.IsWithinBounds(config.Width, config.Height))
            {
                throw new ArgumentOutOfRangeException(nameof(config.PlayerStart), "PlayerStart must be within board bounds.");
            }

            var playerId = _idGenerator.Next();
            var entities = new List<EntityState>
            {
                new EntityState(
                    playerId,
                    Faction.Player,
                    PieceType.King,
                    config.PlayerStart,
                    config.StartingHealth)
            };

            return new GameState(config.Width, config.Height, playerId, entities);
        }
    }
}
