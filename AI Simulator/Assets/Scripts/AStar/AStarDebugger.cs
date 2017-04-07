using System.Collections.Generic;
using Assets.Scripts.Level;
using UnityEngine;

namespace Assets.Scripts.AStar {
    public class AStarDebugger : MonoBehaviour {
        [SerializeField]
        private Tile _start, _goal;

        // Use this for initialization
        void Start() {

        }


        public void DebugPath(Stack<Node> path) {
            foreach (var node in path) {
                    node.Tile.Object.GetComponent<SpriteRenderer>().color = Color.green;
            }
        }
    }
}
