using Assets.Scripts.Agents.Behaviours;
using Assets.Scripts.Level;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Agents.States {
    public class DrivingToPitstop : DrivingStateBase {

        private System.Random _rand = new System.Random();

        public override void Enter(AgentBase agent) {

            var startPosition = agent.CurrentTileLocation;
            var finishPosition = new TileLocation(agent.StartedAtTileLocation.X - 1, agent.StartedAtTileLocation.Y);
            Target = finishPosition;
            Start = startPosition;

            base.Enter(agent);
        }
        public override void Execute(AgentBase agent) {
            base.Execute(agent);
            if (agent.Behavior.GetType() == typeof(PathFollowingBehaviour)) {
                var tempBehaviour = (PathFollowingBehaviour)agent.Behavior;
                if (tempBehaviour.Finished()) {
                    Debug.Log("Finished! Change to RepairingState");
                }
                // Here has to come logic if wear is lower than x
                //agent.StateMachine.ChangeState(new RepairingState());
            }
        }

        public override void Exit(AgentBase agent) {
        }
    }
}
