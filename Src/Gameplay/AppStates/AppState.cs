using Manabind.Src.UI.Components;
using Manabind.Src.UI.Components.Basic;
using Manabind.Src.UI.Components.Complex;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace Manabind.Src.Gameplay.AppStates
{
    public abstract class AppState
    {
        #region Fields

        protected ComponentManager componentManager;
        protected MouseState currentMouseState, prevMouseState;
        protected BaseComplexComponent currentHoveredComponent, prevHoveredComponent;

        #endregion

        #region Constructors

        public AppState()
        {
            componentManager = new ComponentManager();
            currentHoveredComponent = null;
            prevHoveredComponent = null;
        }

        #endregion

        #region Properties

        protected abstract string UIDefinitionFilename { get; }

        #endregion

        #region Methods

        public void Update()
        {
            UpdateMouseState();

            // Resolve hovers
            IEnumerable<BaseComplexComponent> hoveredComponents = componentManager.GetAll().Where(component => 
                            component.GetBounds().Contains(currentMouseState.Position) && 
                            component.Visible && 
                            component.Interactive);

            prevHoveredComponent = currentHoveredComponent;

            if (hoveredComponents.Count() > 0)
            {
                currentHoveredComponent = hoveredComponents.Aggregate((c1, c2) => c1.Priority > c2.Priority ? c1 : c2);
            }
            else
            {
                currentHoveredComponent = null;
            }

            //hovered on component
            if (currentHoveredComponent != prevHoveredComponent)
            {
                prevHoveredComponent?.HoverLeave();
                currentHoveredComponent?.Hover();
            }

            //clicked on component
            if (currentHoveredComponent != null && prevHoveredComponent != null &&
                currentHoveredComponent == prevHoveredComponent &&
                currentHoveredComponent.Hovered && currentMouseState.LeftButton == ButtonState.Pressed &&
                prevHoveredComponent.Hovered && prevMouseState.LeftButton == ButtonState.Released)
            {
                currentHoveredComponent.Click();
            }

            UpdateState();
        }

        public void Initialise(GraphicsDevice device, ContentManager content)
        {
            componentManager.InitialiseResources(device, content);
            componentManager.Initialise(new Rectangle(0, 0, AppSettings.WindowWidth, AppSettings.WindowHeight);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            componentManager.GetRoot().Draw(spriteBatch);
        }

        protected abstract void UpdateState();

        private void UpdateMouseState()
        {
            this.prevMouseState = this.currentMouseState;
            this.currentMouseState = Mouse.GetState();
        }

        #endregion
    }
}
