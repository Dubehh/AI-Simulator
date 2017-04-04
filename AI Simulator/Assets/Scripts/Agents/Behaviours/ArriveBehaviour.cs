using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Agents.Behaviors {
    public enum Deceleration {
        Slow = 4,
        Normal = 2,
        Fast = 1
    }

    public class OwnArriveBehaviour : AgentBehaviourBase {
        private readonly Vector3 _target;
        private readonly Deceleration _deceleration;

        public OwnArriveBehaviour(AgentBase agent, Vector3 target, Deceleration deceleration) : base(agent) {
            _target = target;
            _deceleration = deceleration;
        }

        public override AgentTransformation Calculate() {
            var position = Vector3.MoveTowards(Agent.Object.transform.position, _target, (Agent.Speed/_deceleration.GetHashCode()));
            return new AgentTransformation(position);
        }

    }
}
