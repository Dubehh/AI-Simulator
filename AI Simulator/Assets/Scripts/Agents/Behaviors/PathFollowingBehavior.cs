using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using Assets.Scripts.AStar;
using UnityEngine;
using Assets.Scripts.Utils;
using System.Linq;

namespace Assets.Scripts.Agents.Behaviors {
    public class PathFollowingBehavior : AgentBehaviorBase {
        private readonly List<Node> _path;
        private int _currentPoint;
        private readonly float _waypointSeekDistance;
        public PathFollowingBehavior(List<Node> path, float waypointSeekDistance, AgentBase agent) : base(agent) {
            _path = path;
            _currentPoint = 0;
            _waypointSeekDistance = waypointSeekDistance;
        }

        public override AgentTransformation Calculate() {
            if (!Finished()) {
                Debug.Log("Not Finished" + _currentPoint + "Path count" + _path.Count);
                var target = _path[_currentPoint].TileRef.Object.transform.position;
                var turnBehavior = new TurnBehavior(Agent, _path[(_currentPoint < _path.Count - 1 ? _currentPoint + 1 : _currentPoint)].TileRef.Object.transform.position).Calculate();
                if (Vector3.Distance(target, Agent.Object.transform.position) < _waypointSeekDistance * _waypointSeekDistance) { 
                    target = new Vector3(_path[_currentPoint].TileRef.Object.transform.position.x, _path[_currentPoint].TileRef.Object.transform.position.y);
                    _currentPoint++;
                }

                
                var seekBehavior = new SeekBehavior(Agent, target).Calculate();
                return new AgentTransformation(turnBehavior.Rotation.Value, seekBehavior.Position.Value);

            }
            else {
                var target = new Vector3(_path[_currentPoint - 1].TileRef.Object.transform.position.x,
                    _path[_currentPoint - 1].TileRef.Object.transform.position.y);
                return new ArriveBehavior(Agent, target, Deceleration.Slow).Calculate();
            }
        }

        private bool Finished() {
            return _currentPoint >= _path.Count;
        }
    }
}
