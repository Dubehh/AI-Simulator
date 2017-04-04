using UnityEngine;

namespace Assets.Scripts.Agents.Behaviours {
    public enum Deceleration {
        Slow = 3,
        Normal = 2,
        Fast = 1
    }
    public class ArriveBehaviour : AgentBehaviourBase {
        private readonly Vector3 _target;
        private readonly Deceleration _deceleration;

        public ArriveBehaviour(AgentBase agent, Vector3 target, Deceleration deceleration) : base(agent) {
            _target = target;
            _deceleration = deceleration;
        }
        public override AgentTransformation Calculate() {
            var desired = _target - Agent.Object.transform.position;
            var distance = desired.magnitude;

            if (distance <= 0f) return new AgentTransformation(Agent.Object.transform.position);
            else if (distance < 1f)
                desired = desired.normalized * Agent.Speed * (distance / 1f);
            else desired = desired.normalized * Agent.Speed;
            return new AgentTransformation(IsDefault(desired.normalized) ? desired : Agent.Object.transform.position);
        }

        public bool IsDefault(Vector3 a) {
            return a.x == 0 && a.y == 0 && a.z == 0;
        }


    }
}
