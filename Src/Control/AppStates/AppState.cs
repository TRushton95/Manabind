using Manabind.Src.UI.Components;
using Manabind.Src.UI.Components.BaseInstanceResources;
using Manabind.Src.UI.Components.Complex;
using Manabind.Src.UI.Enums;
using Manabind.Src.UI.Events;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace Manabind.Src.Control.AppStates
{
    public abstract class AppState : BaseInstance
    {
        #region Fields

        protected ComponentManager componentManager;
        protected MouseState currentMouseState, prevMouseState;
        protected BaseComplexComponent currentHoveredComponent, prevHoveredComponent;
        protected bool uiInteracted;

        #endregion

        #region Constructors

        public AppState()
        {
            componentManager = new ComponentManager();
            componentManager.LoadUI(this.UIDefinitionFilename);
            currentHoveredComponent = null;
            prevHoveredComponent = null;
            uiInteracted = false;
        }

        #endregion

        #region Properties

        protected abstract string UIDefinitionFilename { get; }

        #endregion

        #region Methods

        public void Update()
        {
            this.UpdateMouseState();

            this.uiInteracted = false;
            this.HandleMouseState();

            this.UpdateState();
        }

        public virtual void Initialise()
        {
            componentManager.Initialise(new Rectangle(0, 0, AppSettings.WindowWidth, AppSettings.WindowHeight));

            this.InitialiseState();

            EventManager.PushEvent(
                new UIEvent(new EventDetails(this.Name, EventType.Initialise), this));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            componentManager.GetRoot().Draw(spriteBatch);

            this.DrawState(spriteBatch);
        }

        protected virtual void InitialiseState()
        {
        }

        protected virtual void UpdateState()
        {
        }

        protected virtual void DrawState(SpriteBatch spriteBatch)
        {
        }

        private void UpdateMouseState()
        {
            this.prevMouseState = this.currentMouseState;
            this.currentMouseState = Mouse.GetState();
        }

        private void HandleMouseState()
        {
            // Resolve hovers
            IEnumerable<BaseComplexComponent> hoveredComponents = componentManager.GetAll().Where(component =>
                            component.GetBounds().Contains(currentMouseState.Position) &&
                            component.Visible &&
                            component.Interactive);

            prevHoveredComponent = currentHoveredComponent;

            if (hoveredComponents.Count() > 0)
            {
                currentHoveredComponent = hoveredComponents.Aggregate((c1, c2) => c1.Priority > c2.Priority ? c1 : c2);
                uiInteracted = true;
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
        }

        #endregion
    }
}
