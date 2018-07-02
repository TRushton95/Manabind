using Manabind.Src.Control.AppStates;
using Manabind.Src.UI.Components.BaseInstanceResources;
using Manabind.Src.UI.Enums;
using Manabind.Src.UI.Events;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Manabind.Src.Control
{
    public class GameManager : BaseInstance
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
            this.InitialiseResources(device, content);

            appState = new MenuAppState();
            appState.Initialise();

            this.EventResponses.Add(new EventResponse(new UIEvent("play-button", EventType.Click), "play"));
            this.EventResponses.Add(new EventResponse(new UIEvent("editor-button", EventType.Click), "editor"));
            this.EventResponses.Add(new EventResponse(new UIEvent("options-button", EventType.Click), "options"));
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
            appState.Initialise();
        }

        private void SwitchToPlayState()
        {
            appState = new PlayAppState();
            appState.Initialise();
        }

        private void SwitchToOptionsState()
        {
            appState = new OptionsAppState();
            appState.Initialise();
        }

        private void SwitchToEditorState()
        {
            appState = new EditorAppState();
            appState.Initialise();
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

                case "editor":
                    this.SwitchToEditorState();
                    break;

                case "options": this.SwitchToOptionsState();
                    break;

                case "exit": this.Exit();
                    break;
            }
        }

        #endregion
    }
}
