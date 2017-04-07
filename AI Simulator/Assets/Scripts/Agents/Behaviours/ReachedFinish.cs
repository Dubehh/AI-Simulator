using Assets.Scripts.Agents.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Agents.Behaviours {
    class ReachedFinish : IState {
        public void Enter(AgentBase agent) {

        }

        public void Execute(AgentBase agent) {
            agent.FinishedLaps++;
            Debug.Log("IS FINISHED!, wear of the agent is now: " + agent.Wear + ", finished laps: "+ agent.FinishedLaps);
            if (agent.Wear < 50) {
                // Here has to come logic if wear is lower than x
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
