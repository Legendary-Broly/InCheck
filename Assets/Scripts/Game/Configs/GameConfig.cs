using UnityEngine;

namespace InCheck.Game.Configs
{
    [CreateAssetMenu(menuName = "InCheck/Game Config", fileName = "GameConfig")]
    public sealed class GameConfig : ScriptableObject
    {
        [SerializeField] private int startingHealth = 10;
        [SerializeField] private int actionPointsPerTurn = 2;
        [SerializeField] private int boardWidth = 6;
        [SerializeField] private int boardHeight = 6;

        public int StartingHealth => startingHealth;
        public int ActionPointsPerTurn => actionPointsPerTurn;
        public int BoardWidth => boardWidth;
        public int BoardHeight => boardHeight;
    }
}
