using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Level {
    public struct TileLocation {
        public int X { get; set; }
        public int Y { get; set; }

        public TileLocation(int x, int y) : this() {
            X = x;
            Y = y;
        }

        public TileLocation(Vector3 vector) : this((int) vector.x, (int) vector.y) { }
        public static bool operator ==(TileLocation first, TileLocation second) {
            return first.X == second.X && first.Y == second.Y;
        }

        public static bool operator !=(TileLocation first, TileLocation second) {
            return first.X != second.X || first.Y != second.Y;
        }
    }
}
