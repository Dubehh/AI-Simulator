using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Agents.States {
    public interface IState {
        void Enter(AgentBase entity);
        void Execute(AgentBase entity);
        void Exit(AgentBase entity);
    }
}
