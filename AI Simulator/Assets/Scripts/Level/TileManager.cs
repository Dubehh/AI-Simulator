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
            _worldStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));
        }

        public static TileManager GetInstance() {
            return _instance ?? (_instance = new TileManager());
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
