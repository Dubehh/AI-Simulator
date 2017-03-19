using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Level {
    public class TileManager {

        public Tile[,] Tiles { get; private set; }

        private static TileManager _instance;

        private readonly Vector3 _worldStart;
        private readonly Dictionary<string, Sprite> _spriteRegister;
        private readonly string _spritePath;

        /// <summary>
        /// Temporary
        /// </summary>
        private int[,] Temp = new int[,] {
           { 0, 0, 0, 0, 0, 0, 0, 0},
           { 0, 1, 1, 1, 1, 1, 1, 0}, 
           { 0, 1, 1, 1, 1, 1, 1, 0},
           { 0, 1, 1, 0, 0, 1, 1, 0},
           { 0, 1, 1, 0, 0, 1, 1, 0},
           { 0, 1, 1, 1, 1, 1, 1, 0},
           { 0, 1, 1, 1, 1, 1, 1, 0},
           { 0, 0, 0, 0, 0, 0, 0, 0}
        };

        private TileManager() {
            Tiles = new Tile[10, 10];
            _spriteRegister = new Dictionary<string, Sprite>();
            _worldStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));
            _spritePath = "Assets/Sprites/";
        }

        public static TileManager GetInstance() {
            return _instance ?? (_instance = new TileManager());
        }

        public Sprite GetSprite(string name, string extension) {
            if (!_spriteRegister.ContainsKey(name)) {
                var obj = AssetDatabase.LoadAssetAtPath(_spritePath + name + "." + extension, typeof(Sprite));
                _spriteRegister[name] = (Sprite) obj;
            }
            return _spriteRegister[name];
        }

        private void Register(int row, int column, Tile tile) {
            Tiles[row, column] = tile;
        }

        public void Load() {
            for (var y = 0; y < Temp.GetLength(0); y++) {
                for (var x = 0; x < Temp.GetLength(1); x++) {
                    var type = (TileType) Temp[y, x];
                    var tile = new Tile(type);
                    var size = tile.Sprite.bounds.size.x;
                    tile.Object.transform.position = new Vector3(_worldStart.x + size*x, _worldStart.y - size*y, 0);
                }
            }
        }
    }
}
