using System.Collections.Generic;
using Assets.Scripts.AStar;
using UnityEngine;

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
                var target = _path[_currentPoint].Tile.Object.transform.position;
                var turnBehavior = new TurnBehaviour(Agent, _path[(_currentPoint < _path.Count - 1 ? _currentPoint + 1 : _currentPoint)].Tile.Object.transform.position).Calculate();
                if (Vector3.Distance(target, Agent.Object.transform.position) < _waypointSeekDistance * _waypointSeekDistance) {
                    Agent.TileLocation = _path[_currentPoint].Tile.TileLocation;
                    _currentPoint++;
                }
                var seekBehavior = new SeekBehaviour(Agent, target).Calculate();
                return new AgentTransformation(turnBehavior.Rotation.Value, seekBehavior.Position.Value);
            }
            else {
                var target = new Vector3(_path[_currentPoint - 1].Tile.Object.transform.position.x,
                    _path[_currentPoint - 1].Tile.Object.transform.position.y);
                return new ArriveBehaviour(Agent, target, Deceleration.Slow).Calculate();
            }
        }

        private bool Finished() {
            return _currentPoint >= _path.Count;
        }
    }
}
