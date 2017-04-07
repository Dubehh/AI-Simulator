using System.Collections.Generic;
using Assets.Scripts.Agents.Agents;
using Assets.Scripts.Level;
using UnityEngine;
using Assets.Scripts.Agents.States;
using System.Linq;
using System;

namespace Assets.Scripts.Agents {
    public class AgentManager {

        public List<AgentBase> Agents { get; private set; }
        public GameObject Parent { get; private set; }
        private static AgentManager _instance;

        private AgentManager() {
            Agents = new List<AgentBase>();
            Parent = new GameObject() { name = "Agents" };
        }

        public static AgentManager GetInstance() {
            return _instance ?? (_instance = new AgentManager());
        }

        public void Load() {
            var agents = new AgentBase[] { new RedCarAgent(),  new BlueCarAgent(), new GreenCarAgent() };
            var startingTiles = TileManager.GetInstance().OrderedTiles[TileType.Finish];

            for (var i = 0; i < startingTiles.Count; i++) {
                if (i < agents.Length) {
                    agents[i].Initialize(startingTiles[i].TileLocation);
                    //Debug.Log("AgentManager.Load(), finish: " + startingTiles[i].TileLocation.X + ", " + startingTiles[i].TileLocation.Y);

                    agents[i].StateMachine.ChangeState(new DrivingToFinish());

                }
            }

        }

        internal void TriggerAStar() {
            foreach(var agent in Agents) {
                var type = agent.StateMachine.CurrentState.GetType();
                Debug.Log(type);
                agent.StateMachine.ChangeState((IState)Activator.CreateInstance(type));
            }
        }

        public void Update() {
            Agents.ForEach(agent => agent.Update());
        }
    }
}
