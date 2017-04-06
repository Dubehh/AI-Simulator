using Assets.Scripts.Agents.Behaviours;
using Assets.Scripts.Level;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Agents.States {
    public class DrivingToPitstop : DrivingStateBase {

        private System.Random _rand = new System.Random();

        public override void Enter(AgentBase agent) {

            var startFromPosition = agent.StartedAtTileLocation;
            var finishPosition = new TileLocation(14, 6);
            Target = finishPosition;
            Start = new TileLocation(startFromPosition.X+1, startFromPosition.Y);

            base.Enter(agent);
        }
        public override void Execute(AgentBase agent) {
            base.Execute(agent);
            if (agent.Behavior.GetType() == typeof(PathFollowingBehaviour)) {
                var tempBehaviour = (PathFollowingBehaviour)agent.Behavior;
                if (tempBehaviour.Finished()) {
                    Debug.Log("Finished! Change to RepairingState");
                    agent.StateMachine.ChangeState(new RepairingVehicle());
                }
            }
        }

        public override void Exit(AgentBase agent) {
        }
    }
}
