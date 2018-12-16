namespace Manabind.Src.Gameplay.Abilities.Ticks
{
    public abstract class BaseTick
    {
        #region Constructors

        public BaseTick(int duration)
        {
            this.Duration = duration;
        }

        #endregion

        #region Properties

        public int Duration
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public void Tick()
        {
            TickResolution();
            Duration--;
        }

        public abstract void TickResolution();

        #endregion
    }
}
