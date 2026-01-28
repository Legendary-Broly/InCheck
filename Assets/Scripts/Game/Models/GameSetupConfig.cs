namespace InCheck.Game.Models
{
    public readonly struct GameSetupConfig
    {
        public int Width { get; }
        public int Height { get; }
        public int StartingHealth { get; }
        public Coord PlayerStart { get; }

        public GameSetupConfig(int width, int height, int startingHealth, Coord playerStart)
        {
            Width = width;
            Height = height;
            StartingHealth = startingHealth;
            PlayerStart = playerStart;
        }
    }
}
