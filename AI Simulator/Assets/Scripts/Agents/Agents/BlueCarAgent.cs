using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Agents.Behaviours;
using Assets.Scripts.Level;
using UnityEngine;
using Assets.Scripts.Agents.States;

namespace Assets.Scripts.Agents.Agents {
    public class BlueCarAgent : AgentBase {

        public BlueCarAgent() : base("car_blue", 0.02f, 6f) {
        }

        public override void Load() {
           
        }

        public override void Update() {
            StateMachine.Update();
        }
    }
}
