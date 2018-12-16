using Manabind.Src.Gameplay.Entities.Tiles;
using Manabind.Src.UI.Enums;

namespace Manabind.Src.Gameplay.Abilities.Effects
{
    public class HoTEffect : BaseEffect
    {
        #region Constructors

        public HoTEffect(int value, int duration, TargetType targetType, Unit caster)
            :base(targetType, caster)
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

        #endregion

        #region Methods

        public override string GetDescription()
        {
            return $"Heals {this.Value} health per turn for {this.Duration} turns.";
        }

        #endregion
    }
}
