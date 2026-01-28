using InCheck.Game.Interfaces;
using InCheck.Game.Models;

namespace InCheck.Game.Services
{
    public sealed class IncrementingEntityIdGenerator : IEntityIdGenerator
    {
        private int _nextId;

        public IncrementingEntityIdGenerator(int startingId = 1)
        {
            _nextId = startingId;
        }

        public EntityId Next()
        {
            var id = _nextId;
            _nextId += 1;
            return new EntityId(id);
        }
    }
}
