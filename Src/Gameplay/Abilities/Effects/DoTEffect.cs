using Manabind.Src.UI.Enums;

namespace Manabind.Src.Gameplay.Abilities.Effects
{
    public class DoTEffect : BaseEffect
    {
        #region Constructors

        public DoTEffect(int value, int duration, TargetType targetType, int casterId)
            : base(targetType, casterId)
        {
            this.Value = value;
            this.Duration = duration;
        }

        #endregion

        #region Properties

        public int Value
        {
            get;
            set;
        }

        public int Duration
        {
            get;
            set;
        }

        public Unit Target
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public override string GetDescription()
        {
            return $"Deals {this.Value} damage per turn for {this.Duration} turns.";
        }

        #endregion
    }
}
