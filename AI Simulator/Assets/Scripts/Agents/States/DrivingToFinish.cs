using Assets.Scripts.Agents.Behaviours;
using UnityEngine;

namespace Assets.Scripts.Agents.States {
    public class DrivingToFinish : DrivingStateBase {
        public override void Execute(AgentBase agent) {
            base.Execute(agent);

            if (agent.Behavior.GetType() == typeof(PathFollowingBehaviour)) {
                var tempBehaviour = (PathFollowingBehaviour)agent.Behavior;
                if (tempBehaviour.Finished()) {
                    agent.StateMachine.ChangeState(new DrivingToFinish());
                }
            }
        }
        public override void Exit(AgentBase agent) {
            Debug.Log("Exiting DrivingToFinish");
        }
    }
}
