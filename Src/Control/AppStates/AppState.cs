using Manabind.Src.UI.Components;
using Manabind.Src.UI.Components.BaseInstanceResources;
using Manabind.Src.UI.Components.Complex;
using Manabind.Src.UI.Enums;
using Manabind.Src.UI.Events;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Manabind.Src.Control.AppStates
{
    public abstract class AppState : BaseInstance
    {
        #region Fields

        protected ComponentManager componentManager;
        protected BaseComplexComponent currentHoveredComponent, prevHoveredComponent;
        protected bool uiInteracted;

        #endregion

        #region Constructors

        public AppState()
        {
            this.Name = "appstate";

            componentManager = new ComponentManager();
            componentManager.LoadUI(this.UIDefinitionFilename);
            currentHoveredComponent = null;
            prevHoveredComponent = null;
            uiInteracted = false;

            this.InitialiseListen(string.Empty); //No parent

            this.EventResponses.Add(new EventResponse(
                new EventDetails(EventManager.Wildcard, EventType.RefreshTree), "refresh-tree"));
        }

        #endregion

        #region Properties

        public bool Blocked
        {
            get;
            set;
        }

        protected abstract string UIDefinitionFilename { get; }
        
        #endregion

        #region Methods

        public void Update()
        {
            this.uiInteracted = false;

            this.HandleKeyboardState();
            this.HandleMouseState();
            this.UpdateState();

            componentManager.Update();
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
            this.DrawState(spriteBatch);

            componentManager.GetRoot().Draw(spriteBatch);
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

        protected override void ExecuteEventResponse(string action, object content)
        {
            base.ExecuteEventResponse(action, content);

            switch (action)
            {
                case "refresh-tree":
                    componentManager.RefreshTree();
                    EventManager.Subscribe(this); //really dodgy way of handling this

                    break;
            }
        }

        private void HandleMouseState()
        {
            // Resolve hovers
            IEnumerable<BaseComplexComponent> hoveredComponents = componentManager.GetAll().Where(component =>
                            component.GetBounds().Contains(MouseInfo.Position) &&
                            component.Visible &&
                            component.Interactive);

            prevHoveredComponent = currentHoveredComponent;

            // Calculate if blockers exist
            IEnumerable<BaseComplexComponent> blockers = componentManager.GetAll().Where(c => c.Blocker && c.Visible);
            List<BaseComplexComponent> blockerChildren = new List<BaseComplexComponent>();
            this.Blocked = false;

            if (blockers.Count() > 0)
            {
                BaseComplexComponent topBlocker = blockers?.Aggregate((c1, c2) => c1.Priority > c2.Priority ? c1 : c2);
                blockerChildren = componentManager.GetDescendants(topBlocker.Id);
                this.Blocked = true;
            }

            // Get hovered component
            if (hoveredComponents.Count() > 0)
            {
                currentHoveredComponent = hoveredComponents?.Aggregate((c1, c2) => c1.Priority > c2.Priority ? c1 : c2);
                uiInteracted = currentHoveredComponent?.Priority > 0 ? true : false;

                // Unhover if not top blocker
                if (this.Blocked && !blockerChildren.Contains(currentHoveredComponent))
                {
                    currentHoveredComponent = null;
                    uiInteracted = true;
                }

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
            if (currentHoveredComponent != null)
            {
                if (MouseInfo.LeftMouseDown)
                {
                    currentHoveredComponent.LeftMouseDown();

                    if (MouseInfo.LeftMouseClicked)
                    {
                        currentHoveredComponent.LeftClick();
                    }
                }

                if (MouseInfo.RightMouseClicked)
                {
                    currentHoveredComponent.RightClick();
                }
            }
        }

        private void HandleKeyboardState()
        {
            Keys[] pressedKeys = KeyboardInfo.GetPressedKeys();

            if (pressedKeys.Count() > 0)
            {
                foreach (Keys key in pressedKeys)
                {
                    EventManager.PushEvent(
                        new UIEvent(new EventDetails("keyboard", EventType.KeyPress), key));
                }
            }
        }

        #endregion
    }
}
