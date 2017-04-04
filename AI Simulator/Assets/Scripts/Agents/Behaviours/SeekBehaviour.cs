using UnityEngine;

namespace Assets.Scripts.Agents.Behaviours {
    class SeekBehaviour : AgentBehaviourBase {
        private readonly Vector3 _seekTarget;

        public SeekBehaviour(AgentBase agent, Vector3 seekTarget) : base(agent) {
            _seekTarget = seekTarget;
        }

        public override AgentTransformation Calculate() {
            var position = Vector3.MoveTowards(Agent.Object.transform.position, _seekTarget, Agent.Speed);
            return new AgentTransformation(position);
        }

    }
}
