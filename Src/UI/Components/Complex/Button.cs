using System;
using Manabind.Src.UI.Components.Basic;
using Manabind.Src.UI.PositionProfiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Manabind.Src.UI.Enums;
using Manabind.Src.UI.Components.BaseInstanceResources;

namespace Manabind.Src.UI.Components.Complex
{
    public class Button : BaseComplexComponent
    {
        #region Fields

        private Frame frame;
        private TextBox textBox;

        #endregion

        #region Constructors

        public Button()
            : base()
        {
        }

        public Button(int width, int height, string text, BasePositionProfile positionProfile, Color textColour, Color backgroundColour)
            : base(positionProfile)
        {
            frame = new Frame(width, height, positionProfile, backgroundColour);
            textBox = new TextBox(text, width, 20, positionProfile, FontFlow.Shrink, textColour, Textures.ButtonFont); 
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            frame.Draw(spriteBatch);
            textBox.Draw(spriteBatch);
        }

        public override void Initialise()
        {
            frame.Initialise();
            textBox.Initialise();
        }

        public override void OnClick()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Methods



        #endregion
    }
}
