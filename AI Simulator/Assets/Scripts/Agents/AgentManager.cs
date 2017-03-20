using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Agents.Agents;

namespace Assets.Scripts.Agents {
    public class AgentManager {

        public List<AgentBase> Agents { get; private set; }

        private static AgentManager _instance;

        private AgentManager() {
            Agents = new List<AgentBase>();
        }

        public static AgentManager GetInstance() {
            return _instance ?? (_instance = new AgentManager());
        }

        public void Load() {
            var agent = new RedCarAgent();
            agent.Initialize();
        }

        public void Update() {
            Agents.ForEach(agent => agent.Update());
        }
    }
}
