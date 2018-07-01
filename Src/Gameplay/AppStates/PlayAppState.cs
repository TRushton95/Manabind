namespace Manabind.Src.Gameplay.AppStates
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

        protected override void UpdateState()
        {

        }

        #endregion
    }
}
