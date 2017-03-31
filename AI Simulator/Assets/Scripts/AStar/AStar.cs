using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Level;
using UnityEngine;

namespace Assets.Scripts.AStar {
   public class AStar {

        private static Dictionary<TileLocation, Node> _nodes;

        private static void CreateNodes() {
            _nodes = new Dictionary<TileLocation, Node>();
            foreach (var tile in TileManager.GetInstance().Tiles.Values) {
                _nodes.Add(tile.TileLocation, new Node(tile));
            }
        }

        public static void GetPath(TileLocation start, TileLocation goal) {
            if (_nodes == null) {
                CreateNodes();
            }
            var currentNode = _nodes[start];
            var openList = new HashSet<Node>();
            var finalPath = new Stack<Node>();

            openList.Add(currentNode);

            while (openList.Count > 0) {
                for (var x = -1; x <= 1; x++) {
                    for (var y = -1; y <= 1; y++) {
                        // Disallow diagonally walking
                        if (!(x == -1 && (y == -1 || y == 1) || x == 1 && (y == -1 || y == 1))) {
                            var neighborPos = new TileLocation(currentNode.GridPosition.X - x, currentNode.GridPosition.Y - y);
                            if (TileManager.GetInstance().InBounds(neighborPos) && TileManager.GetInstance().Tiles[neighborPos].Walkable &&
                                neighborPos != currentNode.GridPosition) {
                                var gCost = 1;
                                var neighbor = _nodes[neighborPos];
                                if (openList.Contains(neighbor)) {
                                    if (currentNode.G + gCost < neighbor.G) {
                                        neighbor.CalcValues(currentNode, gCost, _nodes[goal]);
                                    }
                                }
                                else if (!neighbor.Closed) {
                                    openList.Add(neighbor);
                                    neighbor.CalcValues(currentNode, gCost, _nodes[goal]);
                                }
                            }
                        }
                    }
                }
                openList.Remove(currentNode);
                currentNode.Closed = true;

                if (openList.Count > 0) {
                    currentNode = openList.OrderBy(x => x.F).First();
                }

                if (currentNode == _nodes[goal]) {
                    while (currentNode.GridPosition != start) {
                        finalPath.Push(currentNode);
                        currentNode = currentNode.Parent;
                    }
                    break;
                }
            }
            GameObject.Find("AStarDebugger").GetComponent<AStarDebugger>().DebugPath(openList, finalPath);

        }
    }
}
