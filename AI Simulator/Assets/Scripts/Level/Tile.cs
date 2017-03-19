using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Level {

    public class Tile {

        public GameObject Object { get; private set; }
        public Sprite Sprite { get; private set; }
        public bool Walkable { get; set; }
        public List<Tile> Adjacent { get; private set; }

        public Tile(string spritename, string extension = "png", bool walkable = false) {
            Walkable = walkable;
            Adjacent = new List<Tile>();
            Sprite = TileManager.GetInstance().GetSprite(spritename, extension);
            Object = new GameObject();
            Object.AddComponent<SpriteRenderer>();
            Object.GetComponent<SpriteRenderer>().sprite = Sprite;
        }

        public Tile(TileType type, bool walkable = false)
            : this("tile_" + Enum.GetName(typeof(TileType), type).ToLower(), "png", walkable) { }


    }
}
