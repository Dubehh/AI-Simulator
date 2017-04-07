using Assets.Scripts.Agents.Behaviours;
using Assets.Scripts.Level;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Agents.States {
    public class DrivingToPitstop : DrivingStateBase {

        private System.Random _rand = new System.Random();

        public override void Enter(AgentBase agent) {
            TileLocation startPosition;

            if (agent.StateMachine.PreviousState.GetType() == typeof(ReachedFinish)) {

                startPosition = new TileLocation(agent.StartedAtTileLocation.X + 1, agent.StartedAtTileLocation.Y);
            }
            else {
                startPosition = agent.CurrentTileLocation;
            }
            var finishPosition = TileManager.GetInstance().OrderedTiles[TileType.Repair].FirstOrDefault().TileLocation;
            Target = finishPosition;
            Start = startPosition;

            base.Enter(agent);
        }
        public override void Execute(AgentBase agent) {
            base.Execute(agent);
            if (agent.Behavior.GetType() == typeof(PathFollowingBehaviour)) {
                var tempBehaviour = (PathFollowingBehaviour)agent.Behavior;
                if (tempBehaviour.Finished()) {
                    UICore.GetInstance().Log(agent.Name + ": I need to repair my ride..");
                    agent.StateMachine.ChangeState(new RepairingVehicle());
                }
            }
        }

        public override void Exit(AgentBase agent) {
        }
    }
}
