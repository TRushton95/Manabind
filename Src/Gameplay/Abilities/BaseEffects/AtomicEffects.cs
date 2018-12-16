namespace Manabind.Src.Gameplay.Abilities.BaseEffects
{
    public static class AtomicEffects
    {
        #region Methods

        public static void Damage(Unit target, int value)
        {
            target.CurrentHealth -= value;

            if (target.CurrentHealth < 0)
            {
                target.CurrentHealth = 0;
            }
        }

        public static void Heal(Unit target, int value)
        {
            target.CurrentHealth += value;

            if (target.CurrentHealth > target.MaxHealth)
            {
                target.CurrentHealth = target.MaxHealth;
            }
        }

        #endregion
    }
}
