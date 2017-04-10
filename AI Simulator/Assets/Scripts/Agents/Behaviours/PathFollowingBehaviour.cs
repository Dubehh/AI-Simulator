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

        /// <summary>
        /// This method will determine the behaviour that has to be calculated 
        /// depending on the completion of the path. When the path is not completed, 
        /// the seek behaviour and turn behaviour will be called with the next target. 
        /// If the path is completed, the arrive behaviour will be called with the last point of the path as the target.
        /// </summary>
        /// <returns></returns>
        public override AgentTransformation Calculate() {
            // If not finished yet, seek and turn to the current target
            if (!Finished()) {

                // To smoothen the turning of an agent, it has to look one node further than the current 
                // target, if that is possible
                var turnBehavior = new TurnBehaviour(Agent, _path[(_currentPoint < _path.Count - 1 ? _currentPoint + 1 : _currentPoint)].Tile.Object.transform.position).Calculate();
                var target = _path[_currentPoint].Tile.Object.transform.position;

                // Calculate the distance between current position and current target position
                var toTarget = target - Agent.Object.transform.position;

                // If the distance is below the distance we've given as distance where a point 
                // should be marked as reached, set the target to the next target
                if (toTarget.sqrMagnitude < _waypointSeekDistance * _waypointSeekDistance) {
                    _currentPoint++;

                    // If the current point is in range of the list, set the target to that point
                    // and update the tile location of the agent, so it knows the tile where it is at
                    // for the A* algorithm
                    if (_currentPoint < _path.Count - 1) {
                        Agent.CurrentTileLocation = _path[_currentPoint].Tile.TileLocation;
                        target = _path[_currentPoint].Tile.Object.transform.position;
                    }
                }
                // Calculate where the target should be, depending on the current position, 
                // the target position and the agent speed
                var seekBehavior = new SeekBehaviour(Agent, target).Calculate();
                return new AgentTransformation(turnBehavior.Rotation.Value, seekBehavior.Position.Value);
            }

            // If the path is finished, and the current point is above null 
            // (because else -1 as index is possible, when the path is empty, for example)
            // set the target to the last point of the path
            if (_currentPoint > 0) {
                var target = _path[_currentPoint - 1].Tile.Object.transform.position;
                return new ArriveBehaviour(Agent, target, Deceleration.Normal).Calculate();
            }

            // No conditions where true, so there has to happen nothing to the position and rotation of 
            // the agent.
            return new AgentTransformation();
        }

        public List<Node> GetPath() {
            return _path;
        }


        public bool Finished() {
            return _currentPoint >= _path.Count;
        }
    }
}
