﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Level {

    public class Tile {

        public GameObject Object { get; private set; }
        public Sprite Sprite { get; set; }
        public TileLocation TileLocation { get; set; }
        public bool Walkable { get; set; }
        public TileType Type { get; set; }
        public readonly Color Color;

        public Tile(string spritename, string extension = "png", bool walkable = false) {
            Walkable = walkable;
            Sprite = SpriteManager.GetInstance().GetSprite(spritename, extension);
            Object = new GameObject();
            SpriteRenderer renderer = Object.AddComponent<SpriteRenderer>();
            renderer.sprite = Sprite;
            Color = renderer.color;
        }

        public void Rotate(float degrees) {
            Object.transform.rotation = Quaternion.Euler(new Vector3(0, 0, degrees));
        }

        public Tile(TileType type, bool walkable = false)
            : this("tile_" + Enum.GetName(typeof(TileType), type).ToLower(), "png", walkable) { }

    }
}
