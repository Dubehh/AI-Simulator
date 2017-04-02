using Assets.Scripts.Level;
using System.Linq;
using System;
using Assets.Scripts.Agents.Behaviors;

namespace Assets.Scripts.Agents.States {
    public abstract class TargetDriving : IState {
        protected TileLocation _destination { get; set; }

        public TargetDriving(TileLocation destination) {
            _destination = destination;
        }
        public void Enter(AgentBase entity) {
            entity.Path = AStar.AStar.GetPath(entity.TileLocation, _destination);
            entity.Behavior = new PathFollowingBehavior(0.1f, entity);
        }

        public virtual void Execute(AgentBase entity) {
            entity.Wear++;
        }

        public abstract void Exit(AgentBase entity);
    }
}
