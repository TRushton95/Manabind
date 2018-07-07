using System;
using Manabind.Src.Gameplay.Interfaces;
using Manabind.Src.UI.Components.Complex;
using Manabind.Src.UI.Enums;
using Microsoft.Xna.Framework.Graphics;

namespace Manabind.Src.Gameplay.Entities
{
    public class Tile : BaseEntity, IIconable
    {
        #region Fields

        public static int Diameter = 100;

        #endregion

        #region Constructors

        public Tile(int posX, int posY, TileType tileType, Texture2D texture)
            : base(posX, posY, texture)
        {
            this.TileType = tileType;
        }

        #endregion

        #region Properties

        public TileType TileType
        {
            get;
            set;
        }
        public Icon Icon
        {
            get;
            set;
        }

        #endregion
    }
}
