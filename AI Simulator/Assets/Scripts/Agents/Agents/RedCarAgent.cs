using System.Linq;
using Assets.Scripts.Agents.Behaviours;
using Assets.Scripts.Level;
using UnityEngine;

namespace Assets.Scripts.Agents.Agents {
    public class RedCarAgent : AgentBase {

        public RedCarAgent() : base("car_red", 1.05f) {
            Speed = 1f;
        }

        public override void Load() {
        }

        public override void Update() {
            StateMachine.Update();
        }
    }
}
