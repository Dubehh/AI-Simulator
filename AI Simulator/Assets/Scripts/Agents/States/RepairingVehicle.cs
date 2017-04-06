﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Agents.States {
    class RepairingVehicle : IState{

        public void Enter(AgentBase agent) {
            //
        }

        public void Execute(AgentBase agent) {
            if (agent.Wear * agent.WearDamage > 0)
                agent.Wear -= agent.WearDamage;
        }

        public void Exit(AgentBase agent) {
            throw new NotImplementedException();
        }
    }
}