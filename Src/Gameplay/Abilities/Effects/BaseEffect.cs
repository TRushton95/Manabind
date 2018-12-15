using Manabind.Src.UI.Enums;

namespace Manabind.Src.Gameplay.Abilities.Effects
{
    public abstract class BaseEffect
    {
        #region Constructors

        public BaseEffect(TargetType targetType, int casterId)
        {
            this.TargetType = targetType;
        }

        #endregion

        #region Properties

        public TargetType TargetType
        {
            get;
            set;
        }

        public int CasterId
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public abstract string GetDescription();

        #endregion
    }
}
