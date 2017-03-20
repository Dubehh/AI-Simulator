﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Level;
using UnityEngine;

namespace Assets.Scripts.AStar {
    public class AStarDebugger : MonoBehaviour {
        [SerializeField]
        private Tile _start, _goal;

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            //ClickTile();

            if (Input.GetKeyDown(KeyCode.Space)) {
                _start = TileManager.GetInstance().Tiles[new TileLocation(3, 1)];
                _start.Object.GetComponent<SpriteRenderer>().color = Color.green;

                _goal = TileManager.GetInstance().Tiles[new TileLocation(2, 5)];
                _goal.Object.GetComponent<SpriteRenderer>().color = Color.red;


                AStar.GetPath(_start.TileLocation, _goal.TileLocation);
            }
        }

        private void ClickTile() {
            if (Input.GetMouseButtonDown(1)) {
                Debug.Log("TEST");
                var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider != null) {
                    var tmp = hit.transform.gameObject;
                    if (tmp != null) {
                        if (_start == null) {

                            tmp.GetComponent<SpriteRenderer>().color = Color.green;
                        }
                        else if (_goal == null) {

                            tmp.GetComponent<SpriteRenderer>().color = Color.red;
                        }
                    }
                }
            }
        }

        public void DebugPath(HashSet<Node> openList, HashSet<Node> closedList, Stack<Node> path) {
            foreach (var node in path) {
                if (node.TileRef != _start && node.TileRef != _goal) {
                    node.TileRef.Object.GetComponent<SpriteRenderer>().color = Color.green;
                }
            }
        }
    }
}
