using Manabind.Src.Gameplay.Abilities.BaseEffects;
using Manabind.Src.Gameplay.Entities.Tiles;
using Manabind.Src.UI.Enums;

namespace Manabind.Src.Gameplay.Abilities.Effects
{
    public class InstantHealEffect : BaseEffect
    {
        #region Constructors

        public InstantHealEffect(int value, TargetType targetType, Unit caster)
            : base(targetType, caster)
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

        public override void Execute(Unit caster, BaseTile targetTile)
        {
            if (!ValidateTarget(targetTile))
            {
                return;
            }

            AtomicEffects.Heal(targetTile.Occupant, Value);
        }

        public override string GetDescription()
        {
            return $"Heals {this.Value} health.";
        }

        #endregion
    }
}
