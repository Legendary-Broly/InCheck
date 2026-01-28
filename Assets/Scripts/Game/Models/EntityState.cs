namespace InCheck.Game.Models
{
    public sealed class EntityState
    {
        public EntityId Id { get; }
        public Faction Faction { get; }
        public PieceType PieceType { get; }
        public Coord Coord { get; set; }
        public int? Hp { get; set; }

        public EntityState(EntityId id, Faction faction, PieceType pieceType, Coord coord, int? hp = null)
        {
            Id = id;
            Faction = faction;
            PieceType = pieceType;
            Coord = coord;
            Hp = hp;
        }
    }
}
