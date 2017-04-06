﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Agents.Behaviours;
using Assets.Scripts.AStar;
using Assets.Scripts.Level;
using UnityEngine;

namespace Assets.Scripts.Agents.States {
    public abstract class DrivingStateBase : IState{
        public TileLocation Start { get; set; }

        public TileLocation Target { get; set; }
        protected DrivingStateBase() {}

        public virtual void Enter(AgentBase agent) {
            Stack<Node> path = AStar.AStar.GetPath(Start, Target);
            agent.Behavior = new PathFollowingBehaviour(path.ToList(), 0.1f, agent);
        }

        public virtual void Execute(AgentBase agent) {
            agent.Wear += agent.Wear * agent.WearDamage;
            var posRot = agent.Behavior.Calculate();
            agent.Object.transform.position = posRot.Position.HasValue ? posRot.Position.Value : agent.Object.transform.position;
            agent.Object.transform.rotation = posRot.Rotation.HasValue ? posRot.Rotation.Value : agent.Object.transform.rotation;
        }

        public abstract void Exit(AgentBase agent);
    }
}
