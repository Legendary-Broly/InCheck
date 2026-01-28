using InCheck.Game.Models;

namespace InCheck.Game.Interfaces
{
    public interface IEntityIdGenerator
    {
        EntityId Next();
    }
}
