using System.Collections.Generic;
using Assets.Scripts.Agents.Agents;
using Assets.Scripts.Level;
using UnityEngine;

namespace Assets.Scripts.Agents {
    public class AgentManager {

        public List<AgentBase> Agents { get; private set; }
        public GameObject Parent { get; private set; }
        private static AgentManager _instance;

        private AgentManager() {
            Agents = new List<AgentBase>();
            Parent = new GameObject() {name = "Agents"};
        }

        public static AgentManager GetInstance() {
            return _instance ?? (_instance = new AgentManager());
        }

        public void Load() {
            var agents = new AgentBase[] {new RedCarAgent(), new BlueCarAgent() };
            var startingTiles = TileManager.GetInstance().OrderedTiles[TileType.Finish];

            for (var i = 0; i < startingTiles.Count; i++)
                agents[i].Initialize(startingTiles[i].TileLocation);
        }

        public void Update() {
            Agents.ForEach(agent => agent.Update());
        }
    }
}
