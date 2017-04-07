using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Agents.Behaviours;
using Assets.Scripts.Level;
using UnityEngine;
using Assets.Scripts.Agents.States;

namespace Assets.Scripts.Agents.Agents {
    public class GreenCarAgent : AgentBase {

        public GreenCarAgent() : base("car_green", 0.03f, 7f) {
        }

        public override void Load() {
           
        }

        public override void Update() {
            StateMachine.Update();
        }
    }
}
