using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Agents.States {
    class RepairingVehicle : IState{

        public void Enter(AgentBase agent) {
            UICore.GetInstance().Log(agent.Name + ": I'm fixing my ride..");
            UICore.GetInstance().Log(agent.Name + ": My wear is "+agent.Wear);
        }

        public void Execute(AgentBase agent) {
            if (agent.Wear > 0)
                agent.Wear -= agent.WearDamage*(Random.Range(7f,9f));
            else {
                agent.Speed = agent.MaxSpeed; 
                agent.StateMachine.ChangeState(new DrivingToFinish());
            }
        }

        public void Exit(AgentBase agent) {
            UICore.GetInstance().Log(agent.Name + ": I've repaired my ride!");
            UICore.GetInstance().Log(agent.Name + ": My wear is now " + agent.Wear);
        }
    }
}
