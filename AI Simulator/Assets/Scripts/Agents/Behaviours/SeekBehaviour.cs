using UnityEngine;

namespace Assets.Scripts.Agents.Behaviours {
    class SeekBehaviour : AgentBehaviourBase {
        private readonly Vector3 _seekTarget;

        public SeekBehaviour(AgentBase agent, Vector3 seekTarget) : base(agent) {
            _seekTarget = seekTarget;
        }

        /// <summary>
        /// This calculate will calculate what the next position of the agent will be
        /// through the current position of the agent, the target position and the agent speed.
        /// </summary>
        /// <returns>AgentTransformation</returns>
        public override AgentTransformation Calculate() {
            var position = Vector3.MoveTowards(Agent.Object.transform.position, _seekTarget, Agent.Speed);
            return new AgentTransformation(position);
        }

    }
}
