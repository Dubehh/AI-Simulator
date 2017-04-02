﻿using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using Assets.Scripts.AStar;
using UnityEngine;
using Assets.Scripts.Utils;
using System.Linq;

namespace Assets.Scripts.Agents.Behaviors {
    public class PathFollowingBehavior : AgentBehaviorBase {
        private Node _currentNode;
        private readonly float _waypointSeekDistance;
        public PathFollowingBehavior( float waypointSeekDistance, AgentBase agent) : base(agent) {
            _currentNode = agent.Path.Pop();
            _waypointSeekDistance = waypointSeekDistance;
        }

        public override AgentTransformation Calculate() {
            if (!Finished()) {
                var target =_currentNode.Tile.Object.transform.position;

                var turnBehavior = new TurnBehavior(Agent, Agent.Path.Count > 0 ? Agent.Path.Peek().Tile.Object.transform.position : target).Calculate();

                if (Vector3.Distance(target, Agent.Object.transform.position) < _waypointSeekDistance * _waypointSeekDistance) { 
                    target = new Vector3(_currentNode.Tile.Object.transform.position.x, _currentNode.Tile.Object.transform.position.y);
                    Agent.TileLocation = _currentNode.Tile.TileLocation;
                    _currentNode = Agent.Path.Pop();
                }

                var seekBehavior = new SeekBehavior(Agent, target).Calculate();
                return new AgentTransformation(turnBehavior.Rotation.Value, seekBehavior.Position.Value);

            }
            else {
                var target = new Vector3(_currentNode.Tile.Object.transform.position.x,
                   _currentNode.Tile.Object.transform.position.y);
                return new ArriveBehavior(Agent, target, Deceleration.Slow).Calculate();
            }
        }

        private bool Finished() {
            return Agent.Path.Count == 0;
        }
    }
}
