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
            IEnumerable<BaseComplexComponent> hoveredComponents = componentManager.GetAll().Where(component => component.GetBounds().Contains(currentMouseState.Position));

            prevHoveredComponent = currentHoveredComponent;

            if (hoveredComponents.Count() > 0)
            {
                currentHoveredComponent = hoveredComponents.Aggregate((c1, c2) => c1.Priority > c2.Priority ? c1 : c2);
            }
            else
            {
                currentHoveredComponent = null;
            }

            if (currentHoveredComponent != prevHoveredComponent)
            {
                prevHoveredComponent?.OnHoverLeave();
                currentHoveredComponent?.OnHover();
            }

            UpdateState();
        }

        public void Initialise(GraphicsDevice device, ContentManager content, Rectangle window)
        {
            componentManager.InitialiseResources(device, content, window.Width, window.Height);
            componentManager.Initialise(window);
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
