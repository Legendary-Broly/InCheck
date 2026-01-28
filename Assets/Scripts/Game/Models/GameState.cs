using System;
using System.Collections.Generic;

namespace InCheck.Game.Models
{
    public sealed class GameState
    {
        public int Width { get; }
        public int Height { get; }
        public List<EntityState> Entities { get; }
        public EntityId PlayerId { get; set; }
        public List<int> Deck { get; }
        public List<int> Hand { get; }
        public List<int> Discard { get; }
        public List<int> Exhaust { get; }

        public GameState(int width, int height, EntityId playerId, List<EntityState> entities)
        {
            if (width <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width), "Width must be greater than zero.");
            }

            if (height <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(height), "Height must be greater than zero.");
            }

            Width = width;
            Height = height;
            PlayerId = playerId;
            Entities = entities ?? throw new ArgumentNullException(nameof(entities));

            Deck = new List<int>();
            Hand = new List<int>();
            Discard = new List<int>();
            Exhaust = new List<int>();
        }
    }
}
