using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Utils;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Level {
    public class TileManager {
        public Dictionary<TileLocation, Tile> Tiles { get; private set; }
        public float TileSize { get; private set; }
        public WorldSize WorldSize { get; private set; }
        private static TileManager _instance;

        private readonly Vector3 _worldStart;
        private readonly Dictionary<string, Sprite> _spriteRegister;
        private readonly string _spritePath;

        private TileManager() {
            _spriteRegister = new Dictionary<string, Sprite>();
            Tiles = new Dictionary<TileLocation, Tile>();
            _worldStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));
            _spritePath = "Assets/Sprites/";
        }

        public static TileManager GetInstance() {
            return _instance ?? (_instance = new TileManager());
        }

        public Sprite GetSprite(string name, string extension) {
            if (!_spriteRegister.ContainsKey(name)) {
                var obj = AssetDatabase.LoadAssetAtPath(_spritePath + name + "." + extension, typeof(Sprite));
                _spriteRegister[name] = (Sprite)obj;
            }
            return _spriteRegister[name];
        }

        private void Register(int row, int column, Tile tile) {
            var location = new TileLocation(column, row);
            Tiles.Add(location, tile);
        }
        /// <summary>
        /// Load level from file.
        /// This function reads a .txt file and splits it into rows with columns.
        /// Every column has information about the tile type and the degrees of rotation.
        /// 
        /// After the tile is created, it will be added to the dictionary so we can look it up
        /// with the correct TileLocation.    
        /// </summary>
        public void Load() {
            var levelGrid = LevelUtil.ReadLevelAsGrid("Level");
            for (var y = 0; y < levelGrid.Length; y++) {
                for (var x = 0; x < levelGrid[y].Length; x++) {
                    // Split the information, so we have the identifier of the tile type and the degrees of rotation
                    var tileInfo = levelGrid[y][x].Split(':');
                    var type = (TileType)int.Parse(tileInfo[0]);

                    var tile = new Tile(type);
                    tile.Rotate(float.Parse(tileInfo[1]));

                    if (type == TileType.Road)
                    {
                        tile.Walkable = true;
                    }

                    var size = tile.Sprite.bounds.size.x;
                    if (TileSize == 0)
                    {
                        TileSize = size;
                    }

                    tile.Object.transform.position = new Vector3(_worldStart.x + size * x, _worldStart.y - size * y, 0);

                    // Add tile to the dictionary so we can look it up with the correct location
                    var location = new TileLocation(x, y);
                    tile.TileLocation = location;
                    Tiles.Add(location, tile);
                    Debug.Log(location.X + "-"+ location.Y);
                }
            }
            WorldSize = new WorldSize(levelGrid[0].Length * TileSize, levelGrid.Length*TileSize);
        }
        public bool InBounds(TileLocation tileLocation)
        {

            return tileLocation.X >= 0 && tileLocation.Y >= 0
                && tileLocation.X <= WorldSize.Width && tileLocation.Y < WorldSize.Height;
        }
    }
}
