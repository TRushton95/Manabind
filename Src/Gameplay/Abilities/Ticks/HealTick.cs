using Manabind.Src.Gameplay.Abilities.BaseEffects;

namespace Manabind.Src.Gameplay.Abilities.Ticks
{
    public class HealTick : BaseTick
    {
        #region Constructors

        public HealTick(int value, int duration, Unit target)
            : base(duration)
        {
            this.Value = value;
            this.Target = target;
        }

        #endregion

        #region Properties

        public int Value
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

        public override void TickResolution()
        {
            AtomicEffects.Heal(this.Target, this.Value);
        }

        #endregion
    }
}
