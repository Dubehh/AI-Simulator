using Assets.Scripts.Agents.Behaviours;
using Assets.Scripts.Level;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Agents.States {
    public class DrivingToFinish : DrivingStateBase {

        private System.Random _rand = new System.Random();

        public override void Enter(AgentBase agent) {
            var startDrivingTo = Settings.StartFromFinish;
            TileLocation startFromPosition;
            if (startDrivingTo == Direction.Right) {
                if (agent.StateMachine.PreviousState == null || agent.StateMachine.PreviousState.GetType() == typeof(DrivingToFinish)) {

                    startFromPosition = agent.StartedAtTileLocation;
                }
                else {
                    startFromPosition = agent.CurrentTileLocation;
                }
                var startPosition = new TileLocation(startFromPosition.X + 1, startFromPosition.Y);
                var finishPosition = new TileLocation(agent.StartedAtTileLocation.X - 1, agent.StartedAtTileLocation.Y);
                Target = finishPosition;
                Start = startPosition;
            }
            base.Enter(agent);
        }
        public override void Execute(AgentBase agent) {
            base.Execute(agent);
            if (agent.Behavior.GetType() == typeof(PathFollowingBehaviour)) {
                var tempBehaviour = (PathFollowingBehaviour)agent.Behavior;
                if (tempBehaviour.Finished()) {

                    // Here has to come logic if wear is lower than x
                    agent.StateMachine.ChangeState(new DrivingToFinish());
                }
            }
        }
        public override void Exit(AgentBase agent) {
        }
    }
}
