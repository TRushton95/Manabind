using System.Collections.Generic;

namespace Manabind.Src.UI.Serialisation
{
    public class Map
    {
        #region Constructors

        public Map()
        {
        }

        public Map(string name, int width, int height, List<List<Tile>> tiles)
        {
            this.Name = name;
            this.Width = width;
            this.Height = height;
            this.Tiles = tiles;
        }

        #endregion

        #region Properties

        public string Name
        {
            get;
            set;
        }

        public int Width
        {
            get;
            set;
        }

        public int Height
        {
            get;
            set;
        }

        public List<List<Tile>> Tiles
        {
            get;
            set;
        }

        #endregion
    }
}
