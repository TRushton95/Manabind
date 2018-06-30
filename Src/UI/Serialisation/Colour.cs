using Microsoft.Xna.Framework;
using System.Xml.Serialization;

namespace Manabind.Src.UI.Serialisation
{
    public struct Colour
    {
        #region Constructors

        public Colour(byte r, byte g, byte b, byte a)
        {
            R = r;
            G = g;
            B = b;
            A = g;
        }

        public Colour(Color colour)
        {
            R = colour.R;
            G = colour.G;
            B = colour.B;
            A = colour.A;
        }

        #endregion

        #region Properties

        [XmlAttribute("r")]
        public byte R
        {
            get;
            set;
        }

        [XmlAttribute("g")]
        public byte G
        {
            get;
            set;
        }

        [XmlAttribute("b")]
        public byte B
        {
            get;
            set;
        }

        [XmlAttribute("a")]
        public byte A
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public Color GetValue()
        {
            return new Color(R, G, B, A);
        }

        #endregion
    }
}
