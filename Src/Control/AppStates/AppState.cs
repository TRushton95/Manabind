﻿using Manabind.Src.UI.Components;
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
        }

        #endregion

        #region Properties

        protected abstract string UIDefinitionFilename { get; }
        
        #endregion

        #region Methods

        public void Update()
        {
            this.uiInteracted = false;

            this.HandleKeyboardState();
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

        private void HandleMouseState()
        {
            // Resolve hovers
            IEnumerable<BaseComplexComponent> hoveredComponents = componentManager.GetAll().Where(component =>
                            component.GetBounds().Contains(MouseInfo.Position) &&
                            component.Visible &&
                            component.Interactive);

            prevHoveredComponent = currentHoveredComponent;

            if (hoveredComponents.Count() > 0)
            {
                currentHoveredComponent = hoveredComponents.Aggregate((c1, c2) => c1.Priority > c2.Priority ? c1 : c2);
                uiInteracted = currentHoveredComponent.Priority > 0 ? true : false;
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
