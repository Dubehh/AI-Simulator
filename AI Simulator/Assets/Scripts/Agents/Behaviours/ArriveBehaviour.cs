using Assets.Scripts.Agents.Behaviours;
using UnityEngine;

namespace Assets.Scripts.Agents.Behaviors {
    public enum Deceleration {
        Slow = 4,
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
            var position = Vector3.MoveTowards(Agent.Object.transform.position, _target, (Agent.Speed/_deceleration.GetHashCode()));
            return new AgentTransformation(position);
        }

    }
}
