using System.Linq;
using Assets.Scripts.Agents.Behaviours;
using Assets.Scripts.Level;
using UnityEngine;

namespace Assets.Scripts.Agents.Agents {
    public class RedCarAgent : AgentBase {

        public RedCarAgent() : base("car_red") {
            Speed = 1f;
            Wear = 2f;
        }

        public override void Load() {
        }

        public override void Update() {
            StateMachine.Update();
        }
    }
}
