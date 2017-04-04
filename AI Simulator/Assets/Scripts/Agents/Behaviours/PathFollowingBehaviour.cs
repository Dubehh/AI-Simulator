using System.Collections.Generic;
using Assets.Scripts.AStar;
using UnityEngine;

using Assets.Scripts.Utils;
using System.Linq;
using Assets.Scripts.Agents.Behaviors;
using Assets.Scripts.Agents.Behaviours;

namespace Assets.Scripts.Agents.Behaviours {
    public class PathFollowingBehaviour : AgentBehaviourBase {
        private readonly List<Node> _path;
        private int _currentPoint;
        private readonly float _waypointSeekDistance;
        public PathFollowingBehaviour(List<Node> path, float waypointSeekDistance, AgentBase agent) : base(agent) {
            _path = path;
            _currentPoint = 0;
            _waypointSeekDistance = waypointSeekDistance;
        }

        public override AgentTransformation Calculate() {
            if (!Finished()) {
                var turnBehavior = new TurnBehaviour(Agent, _path[(_currentPoint < _path.Count - 1 ? _currentPoint + 1 : _currentPoint)].Tile.Object.transform.position).Calculate();
                var target = _path[_currentPoint].Tile.Object.transform.position;
                var toTarget = target - Agent.Object.transform.position;
                if (toTarget.sqrMagnitude < _waypointSeekDistance * _waypointSeekDistance) {
                    _currentPoint++;
                    if (_currentPoint + 1 < _path.Count) {
                        target = _path[_currentPoint].Tile.Object.transform.position;
                    }
                }
                var seekBehavior = new SeekBehaviour(Agent, target).Calculate();
                return new AgentTransformation(turnBehavior.Rotation.Value, seekBehavior.Position.Value);
            } else {
                var target = _path[_currentPoint - 1].Tile.Object.transform.position;
                return new OwnArriveBehaviour(Agent, target, Deceleration.Normal).Calculate();
            }
        }


        private bool Finished() {
            return _currentPoint >= _path.Count;
        }
    }
}
