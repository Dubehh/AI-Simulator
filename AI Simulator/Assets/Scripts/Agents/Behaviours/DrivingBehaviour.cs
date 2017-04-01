using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Agents.Behaviours {
    public class DrivingBehavior : AgentBehaviorBase {
         
        private float _speed;

        public DrivingBehavior(AgentBase agent, float speed)
            : base(agent) {
            this._speed = speed;   

        }

        public override AgentTransformation Calculate() {
            return new AgentTransformation();
        }
    }
}
