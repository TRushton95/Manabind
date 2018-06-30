using Microsoft.Xna.Framework;
using System.Xml.Serialization;

namespace Manabind.Src.UI.Serialisation
{
    public class Colour
    {
        #region Fields

        private Color _colour;

        #endregion

        #region Constructors

        public Colour()
        {
            this.R = 0;
            this.G = 0;
            this.B = 0;
            this.A = 0;
        }

        public Colour(byte r, byte g, byte b, byte a)
        {
            this.R = r;
            this.G = g;
            this.B = b;
            this.A = g;
        }

        public Colour(Color colour)
        {
            this.R = colour.R;
            this.G = colour.G;
            this.B = colour.B;
            this.A = colour.A;
        }

        #endregion

        #region Properties

        [XmlAttribute("r")]
        public byte R
        {
            get { return this._colour.R; }
            set { this._colour.R = value; }
        }

        [XmlAttribute("g")]
        public byte G
        {
            get { return this._colour.G; }
            set { this._colour.G = value; }
        }

        [XmlAttribute("b")]
        public byte B
        {
            get { return this._colour.B; }
            set { this._colour.B = value; }
        }

        [XmlAttribute("a")]
        public byte A
        {
            get { return this._colour.A; }
            set { this._colour.A = value; }
        }

        #endregion

        #region Methods

        public Color GetColor()
        {
            return this._colour;
        }

        #endregion
    }
}
