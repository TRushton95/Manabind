using Manabind.Src.UI.Enums;

namespace Manabind.Src.Gameplay.Abilities.Effects
{
    public class InstantHealEffect : BaseEffect
    {
        #region Constructors

        public InstantHealEffect(int value, TargetType targetType, int casterId)
            : base(targetType, casterId)
        {
            this.Value = value;
        }

        #endregion

        #region Properties

        public int Value
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public override string GetDescription()
        {
            return $"Heals {this.Value} health.";
        }

        #endregion
    }
}
