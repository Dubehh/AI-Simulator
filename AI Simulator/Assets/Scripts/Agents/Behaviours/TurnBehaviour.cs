using UnityEngine;

namespace Assets.Scripts.Agents.Behaviours {
    public class TurnBehaviour : AgentBehaviourBase {
        private readonly Vector3 _seekTarget;

        public TurnBehaviour(AgentBase agent, Vector3 seekTarget) : base(agent) {
            _seekTarget = seekTarget;
        }

        public override AgentTransformation Calculate() {
            var dir = _seekTarget - Agent.Object.transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            var q = Quaternion.AngleAxis(angle, Vector3.forward);

            return new AgentTransformation(Quaternion.Slerp(Agent.Object.transform.rotation, q, 15f * Time.deltaTime));
        }
    }
}
