using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Level {
    public class TileLocation {
        public int X { get; set; }
        public int Y { get; set; }

        public TileLocation(int x, int y)
        {
            X = x;
            Y = y;
        }
        public static bool operator ==(TileLocation first, TileLocation second) {
            return first.X == second.X && first.Y == second.Y;
        }

        public static bool operator !=(TileLocation first, TileLocation second) {
            return first.X != second.X || first.Y != second.Y;
        }
    }
}
