using Assets.Scripts.Utils;
using UnityEngine;

namespace Assets.Scripts.Agents.Behaviors {
    class SeekBehavior : AgentBehaviorBase {
        private readonly Vector3 _seekTarget;

        public SeekBehavior(AgentBase agent, Vector3 seekTarget) : base(agent) {
            _seekTarget = seekTarget;
        }

        public override AgentTransformation Calculate() {
            var position = Vector3.MoveTowards(Agent.Object.transform.position, _seekTarget, Agent.Property.Speed);
            return new AgentTransformation(position);
        }

    }
}
