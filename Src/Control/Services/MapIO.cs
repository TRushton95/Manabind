using Manabind.Src.Gameplay.Entities;
using Manabind.Src.Gameplay.Entities.Tiles;
using Manabind.Src.UI.Serialisation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Manabind.Src.Control.Services
{
    public static class MapIO
    {
        #region Methods

        public static void SaveMap(Board board, string mapName)
        {
            List<List<Tile>> tilesToSerialize = new List<List<Tile>>();

            foreach (List<BaseTile> column in board.Tiles)
            {
                List<Tile> columnToSerialize = new List<Tile>();

                foreach (BaseTile tile in column)
                {
                    columnToSerialize.Add(
                        new Tile(tile.PosX, tile.PosY, tile.TileType));
                }

                tilesToSerialize.Add(columnToSerialize);
            }

            Map map = new Map()
            {
                Name = mapName,
                Width = board.Width,
                Height = board.Height,
                Tiles = tilesToSerialize
            };

            string json = JsonConvert.SerializeObject(map);

            Directory.CreateDirectory(AppSettings.MapDirectoryPath);
            string fileName = string.Concat(mapName, ".json");
            string mapDirectory = Path.Combine(AppSettings.MapDirectoryPath, fileName);

            File.WriteAllText(mapDirectory, json);
        }

        public static Board LoadMap(string selectedMap)
        {
            if (string.IsNullOrWhiteSpace(selectedMap))
            {
                return null;
            }

            Directory.CreateDirectory(AppSettings.MapDirectoryPath);
            string fileName = string.Concat(selectedMap, ".json");
            string mapDirectory = Path.Combine(AppSettings.MapDirectoryPath, fileName);

            string json = File.ReadAllText(mapDirectory);
            Map map = JsonConvert.DeserializeObject<Map>(json);

            Board result = new Board();

            result.Name = map.Name;
            result.Width = map.Width;
            result.Height = map.Height;
            result.Generate(map);

            return result;
        }

        #endregion
    }
}
