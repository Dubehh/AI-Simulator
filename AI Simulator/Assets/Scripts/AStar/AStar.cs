using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Level;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.AStar {

    public static class AStar {


        /// <summary>
        /// Calculates the fastest route towards a goal using the manhattan heuristic.
        /// This is an implementation of the A* algorithm that compares neighbours of nodes
        /// to see which node is more probable than the other neighbours.
        /// </summary>
        /// <param name="start">The location of which the path will start</param>
        /// <param name="goal">The requested goal location</param>
        /// <returns>A route with all nodes that will be passed </returns>
        public static Stack<Node> GetPath(TileLocation start, TileLocation goal) {
            var _nodes = new Dictionary<TileLocation, Node>();
            foreach (var tile in TileManager.GetInstance().Tiles.Values)
                _nodes.Add(tile.TileLocation, new Node(tile));
            var currentNode = _nodes[start];
            var openList = new HashSet<Node>();
            var closedList = new HashSet<Node>();
            var finalPath = new Stack<Node>();

            openList.Add(currentNode);

            while (openList.Count > 0) {
                for (var x = -1; x <= 1; x++) {
                    for (var y = -1; y <= 1; y++) {
                        if (!(x == -1 && (y == -1 || y == 1) || x == 1 && (y == -1 || y == 1))) {
                            // Disallow diagonally walking
                            var neighborPos = new TileLocation(currentNode.GridPosition.X - x, currentNode.GridPosition.Y - y);
                            if (TileManager.GetInstance().InBounds(neighborPos)
                                && TileManager.GetInstance().Tiles[neighborPos].Type != TileType.Finish
                                && TileManager.GetInstance().Tiles[neighborPos].Walkable
                                && neighborPos != currentNode.GridPosition) {
                                var gCost = 1;
                                var neighbor = _nodes[neighborPos];
                                if (openList.Contains(neighbor)) {
                                    if (currentNode.G + gCost < neighbor.G) {
                                        neighbor.CalcValues(currentNode, gCost, _nodes[goal]);
                                    }
                                }
                                else if (!closedList.Contains(neighbor)) {
                                    openList.Add(neighbor);
                                    neighbor.CalcValues(currentNode, gCost, _nodes[goal]);
                                }
                            }
                        }
                    }
                }
                openList.Remove(currentNode);
                closedList.Add(currentNode);

                if (openList.Count > 0)
                    currentNode = openList.OrderBy(x => x.F).First();

                if (currentNode == _nodes[goal]) {
                    while (currentNode.GridPosition != start) {
                        finalPath.Push(currentNode);
                        currentNode = currentNode.Parent;
                    }
                    finalPath.Push(currentNode);
                    break;
                }
            }
            return finalPath;
        }
    }
}
