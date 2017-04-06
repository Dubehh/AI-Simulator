using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Agents.States {
    class RepairingVehicle : IState{

        public void Enter(AgentBase agent) {
            // log
        }

        public void Execute(AgentBase agent) {
            if (agent.Wear * agent.WearDamage > 0)
                agent.Wear -= agent.WearDamage;
            else {
                agent.StateMachine.ChangeState(new DrivingToFinish());
            }
        }

        public void Exit(AgentBase agent) {
            // log
        }
    }
}
