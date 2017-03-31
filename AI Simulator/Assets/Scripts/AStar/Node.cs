using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Level;

namespace Assets.Scripts.AStar {
   public class Node {
        public TileLocation GridPosition { get; private set; }

        public Tile Tile { get; private set; }
        public Node Parent { get; set; }
        public int G { get; set; }
        public int H { get; set; }
        public int F { get; set; }

        public Node(Tile tile) {
            Tile = tile;
            GridPosition = tile.TileLocation;
        }

        public void CalcValues(Node parent, int g, Node goal) {
            Parent = parent;
            G = parent.G + g;
            H = Math.Abs(GridPosition.X - goal.GridPosition.X) + Math.Abs(GridPosition.Y - goal.GridPosition.Y);
            F = G + H;
        }
    }
}
