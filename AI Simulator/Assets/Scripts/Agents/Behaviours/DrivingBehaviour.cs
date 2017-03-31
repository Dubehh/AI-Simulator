using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Agents.Behaviours {
    public class DrivingBehaviour : AgentBehaviourBase {
         
        private float _speed;

        public DrivingBehaviour(AgentBase agent, float speed)
            : base(agent) {
            this._speed = speed;   

        }

        public override Vector3 Calculate() {
            return new Vector3(3, 3, 0);
        }
    }
}
