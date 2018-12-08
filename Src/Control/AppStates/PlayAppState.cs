namespace Manabind.Src.Control.AppStates
{
    public class PlayAppState : AppState
    {
        #region Constructors

        public PlayAppState()
        {
            componentManager.LoadUI(AppSettings.PlayUIFileName);
        }

        #endregion

        #region Properties

        protected override string UIDefinitionFilename => AppSettings.PlayUIFileName;

        #endregion

        #region Methods

        public void StartGame(string map, int players)
        {
            
        }

        protected override void UpdateState()
        {

        }

        #endregion
    }
}
