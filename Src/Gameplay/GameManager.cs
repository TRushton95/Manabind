using Manabind.Src.Gameplay.AppStates;
using Manabind.Src.UI.Components.BaseInstanceResources;
using Manabind.Src.UI.Enums;
using Manabind.Src.UI.Events;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Manabind.Src.Gameplay
{
    public class GameManager : Listener
    {
        #region Fields

        private AppState appState;

        #endregion

        #region Static Constructors

        public GameManager()
        {
            ReadyToExit = false;
        }

        #endregion

        #region Properties

        public bool ReadyToExit
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public void Initialise(GraphicsDevice device, ContentManager content)
        {
            appState = new MenuAppState();
            appState.Initialise(device, content);

            this.EventResponses.Add(new EventResponse(new UIEvent("play-button", EventType.Click), "play"));
            this.EventResponses.Add(new EventResponse(new UIEvent("options-button", EventType.Click), "options"));
            this.EventResponses.Add(new EventResponse(new UIEvent("help-button", EventType.Click), "help"));
            this.EventResponses.Add(new EventResponse(new UIEvent("exit-button", EventType.Click), "exit"));
        }

        public void Update()
        {
            appState.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            appState.Draw(spriteBatch);
        }

        private void SwitchToMenuState()
        {
            appState = new MenuAppState();
        }

        private void SwitchToPlayState()
        {
            appState = new PlayAppState();
        }

        private void SwitchToOptionsState()
        {
            appState = new OptionsAppState();
        }

        private void SwitchToHelpState()
        {
            appState = new HelpAppState();
        }

        private void Exit()
        {
            ReadyToExit = true;
        }

        protected override void ExecuteEventResponse(string action)
        {
            switch (action)
            {
                case "play": this.SwitchToPlayState();
                    break;

                case "options": this.SwitchToOptionsState();
                    break;

                case "help": this.SwitchToHelpState();
                    break;

                case "exit": this.Exit();
                    break;
            }
        }

        #endregion
    }
}
