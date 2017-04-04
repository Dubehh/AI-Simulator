using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Agents {
    public abstract class AgentBehaviourBase {

        protected AgentBase Agent { get; private set; }

        protected AgentBehaviourBase(AgentBase agent) {
            Agent = agent;
        }

        public abstract AgentTransformation Calculate();
    }
}
