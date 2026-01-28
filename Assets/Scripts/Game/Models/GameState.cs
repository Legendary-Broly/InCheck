namespace InCheck.Game.Models
{
    public sealed class GameState
    {
        public int TurnNumber { get; private set; }
        public int ActionPointsRemaining { get; private set; }
        public int CurrentHealth { get; private set; }

        public GameState(int startingHealth, int actionPointsPerTurn)
        {
            CurrentHealth = startingHealth;
            ActionPointsRemaining = actionPointsPerTurn;
            TurnNumber = 1;
        }

        public void StartNewTurn(int actionPointsPerTurn)
        {
            TurnNumber += 1;
            ActionPointsRemaining = actionPointsPerTurn;
        }

        public void SpendActionPoint()
        {
            if (ActionPointsRemaining <= 0)
            {
                return;
            }

            ActionPointsRemaining -= 1;
        }

        public void ApplyDamage(int amount)
        {
            if (amount <= 0)
            {
                return;
            }

            CurrentHealth = System.Math.Max(0, CurrentHealth - amount);
        }

        public void Heal(int amount)
        {
            if (amount <= 0)
            {
                return;
            }

            CurrentHealth += amount;
        }
    }
}
