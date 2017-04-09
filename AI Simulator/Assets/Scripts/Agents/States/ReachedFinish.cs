using Assets.Scripts.Agents.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Agents.States {
    class ReachedFinish : IState {
        public void Enter(AgentBase agent) {

        }

        public void Execute(AgentBase agent) {
            agent.FinishedLaps++;
            if (agent.Wear < 50) {
                agent.StateMachine.ChangeState(new DrivingToFinish());
            }
            else {
                agent.StateMachine.ChangeState(new DrivingToPitstop());
            }
        }

        public void Exit(AgentBase agent) {
            
        }
    }
}
