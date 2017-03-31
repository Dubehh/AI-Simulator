using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Agents.Agents;
using Assets.Scripts.Level;
using UnityEngine;

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
            var agents = new AgentBase[] {new RedCarAgent(), new RedCarAgent() };
            List<Tile> startingTiles = TileManager.GetInstance().OrderedTiles[TileType.Finish];
            Debug.Log(startingTiles.Count);
            for(var i = 0; i < startingTiles.Count; i++)
                agents[i].Initialize(startingTiles[i].Object.transform.position);
        }

        public void Update() {
            Agents.ForEach(agent => agent.Update());
        }
    }
}
