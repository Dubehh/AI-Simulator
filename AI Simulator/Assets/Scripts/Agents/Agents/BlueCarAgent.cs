﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Agents.Behaviors;
using Assets.Scripts.Level;
using UnityEngine;

namespace Assets.Scripts.Agents.Agents {
    public class BlueCarAgent : AgentBase {

        public BlueCarAgent() : base("car_blue") {
            Speed = 1.2f;
            Wear = 3f;
        }

        public override void Load() {
            var start = TileManager.GetInstance().Tiles[new TileLocation(5, 4)];
            start.Object.GetComponent<SpriteRenderer>().color = Color.green;

            var goal = TileManager.GetInstance().Tiles[new TileLocation(2, 3)];
            goal.Object.GetComponent<SpriteRenderer>().color = Color.red;


            var finalPath = AStar.AStar.GetPath(start.TileLocation, goal.TileLocation);

            Behavior = new PathFollowingBehavior(finalPath.ToList(), 0.1f, this);
        }

        public override void Update() {
            var posRot = Behavior.Calculate();
            Object.transform.position = posRot.Position.Value;
            Object.transform.rotation = posRot.Rotation.HasValue ? posRot.Rotation.Value : Object.transform.rotation;
        }
    }
}