using Manabind.Src.Gameplay.Entities.Tiles;
using Manabind.Src.Gameplay.Services;
using Manabind.Src.UI.Enums;

namespace Manabind.Src.Gameplay.Abilities.Effects
{
    public abstract class BaseEffect
    {
        #region Constructors

        public BaseEffect(TargetType targetType, Unit caster)
        {
            this.TargetType = targetType;
            this.Caster = caster;
        }

        #endregion

        #region Properties

        public TargetType TargetType
        {
            get;
            set;
        }

        public Unit Caster
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public abstract string GetDescription();

        protected bool ValidateTarget(BaseTile targetTile)
        {
            return TargetValidatorService.Validate(this.Caster, targetTile, TargetType);
        }

        #endregion
    }
}
