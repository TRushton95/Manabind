namespace Manabind.Src.UI.Components.BaseInstanceResources
{
    public class Settings
    {
        #region Fields

        private static Settings _instance;

        public static int WindowWidth;
        public static int WindowHeight;

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

        public void Initialise(int width, int height)
        {
            WindowWidth = width;
            WindowHeight = height;
        }

        #endregion
    }
}
