using Manabind.Src.Control.AppStates;
using Manabind.Src.UI.Components.BaseInstanceResources;
using Manabind.Src.UI.Enums;
using Manabind.Src.UI.Events;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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

            this.EventResponses.Add(new EventResponse(new EventDetails("play-button", EventType.LeftClick), "play"));
            this.EventResponses.Add(new EventResponse(new EventDetails("editor-button", EventType.LeftClick), "editor"));
            this.EventResponses.Add(new EventResponse(new EventDetails("options-button", EventType.LeftClick), "options"));
            this.EventResponses.Add(new EventResponse(new EventDetails("exit-button", EventType.LeftClick), "exit"));
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
            appState = new MenuAppState(appState.CurrentMouseState, appState.PrevMouseState);
            appState.Initialise();
        }

        private void SwitchToPlayState()
        {
            appState = new PlayAppState(appState.CurrentMouseState, appState.PrevMouseState);
            appState.Initialise();
        }

        private void SwitchToOptionsState()
        {
            appState = new OptionsAppState(appState.CurrentMouseState, appState.PrevMouseState);
            appState.Initialise();
        }

        private void SwitchToEditorState()
        {
            appState = new EditorAppState(appState.CurrentMouseState, appState.PrevMouseState);
            appState.Initialise();
        }

        private void Exit()
        {
            ReadyToExit = true;
        }

        protected override void ExecuteEventResponse(string action, object content)
        {
            switch (action)
            {
                case "play":
                    this.SwitchToPlayState();
                    break;

                case "editor":
                    this.SwitchToEditorState();
                    break;

                case "options":
                    this.SwitchToOptionsState();
                    break;

                case "exit":
                    this.Exit();
                    break;
            }
        }

        #endregion
    }
}
