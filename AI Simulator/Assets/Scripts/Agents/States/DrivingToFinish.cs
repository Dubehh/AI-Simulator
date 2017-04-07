using Assets.Scripts.Agents.Behaviours;
using Assets.Scripts.Level;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Agents.States {
    public class DrivingToFinish : DrivingStateBase {

        private System.Random _rand = new System.Random();

        public override void Enter(AgentBase agent) {
            var startDrivingTo = Settings.StartFromFinish;

            TileLocation startPosition;

            if (startDrivingTo == Direction.Right) {
                if (agent.StateMachine.PreviousState == null || agent.StateMachine.PreviousState.GetType() == typeof(DrivingToFinish)) {
                    startPosition = new TileLocation(agent.StartedAtTileLocation.X+1, agent.StartedAtTileLocation.Y);
                } else {
                    startPosition = agent.CurrentTileLocation;
                }
                var finishPosition = new TileLocation(agent.StartedAtTileLocation.X - 1, agent.StartedAtTileLocation.Y);
                Target = finishPosition;
                Start = startPosition;
            }
            base.Enter(agent);
        }

        public override void Execute(AgentBase agent) {
            base.Execute(agent);
            if (agent.Behavior.GetType() == typeof(PathFollowingBehaviour)) {
                //Debug.Log("TYPE == PathFollowingBehaviour");
                var tempBehaviour = (PathFollowingBehaviour)agent.Behavior;
                if (tempBehaviour.Finished()) {
                    UICore.GetInstance().Log(agent.Name + ": I finished a lap!");
                    if (agent.Wear < 60) {
                        // Here has to come logic if wear is lower than x
                        agent.StateMachine.ChangeState(new DrivingToFinish());
                    }
                    else {
                        agent.StateMachine.ChangeState(new DrivingToPitstop());
                    }
                }
            }
        }
        public override void Exit(AgentBase agent) {
        }
    }
}
