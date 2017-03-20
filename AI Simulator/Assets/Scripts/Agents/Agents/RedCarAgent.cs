using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Agents.Behaviours;
using UnityEngine;

namespace Assets.Scripts.Agents.Agents {
    public class RedCarAgent : AgentBase {

        public RedCarAgent() : base("car_red") {
            Speed = 5f;
            Wear = 2f;
        }

        public override void Load() {
            
        }

        public override void Update() {
            if(Behaviour == null) Behaviour = new DrivingBehaviour(this, 30f);
            Object.transform.position = Behaviour.Calculate();
        }
    }
}
