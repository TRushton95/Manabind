namespace Manabind.Src.UI.Components.BaseInstanceResources
{
    public class Settings
    {
        #region Fields

        private static Settings _instance;

        #endregion

        #region Properties

        public static Settings Instance
        {
            get
            {
                if (_instance == null)
                {
                    return new Settings();
                }

                return _instance;
            }
        }

        #endregion

        #region Methods

        public void Initialise()
        {
        }

        #endregion
    }
}
