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

        public BlueCarAgent() : base("car_blue") {
            Speed = 1.2f;
            Wear = 3f;
        }

        public override void Load() {
            StateMachine = new StateMachine(this);
            var drivingToFinish = new DrivingToFinish();
            drivingToFinish.Target = TileManager.GetInstance().Tiles[new TileLocation(2, 3)].TileLocation;

            StateMachine.CurrentState = drivingToFinish;
        }

        public override void Update() {
            StateMachine.Update();
        }
    }
}
