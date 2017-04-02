using Assets.Scripts.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Agents.States {
    public class DrivingToPitstop : TargetDriving {
        public DrivingToPitstop(TileLocation destination) : base(destination) {
        }

        public override void Execute(AgentBase entity) {
            var posRot = entity.Behavior.Calculate();
            entity.Object.transform.position = posRot.Position.HasValue ? posRot.Position.Value : entity.Object.transform.position;
            entity.Object.transform.rotation = posRot.Rotation.HasValue ? posRot.Rotation.Value : entity.Object.transform.rotation;
            base.Execute(entity);
        }

        public override void Exit(AgentBase entity) {
            throw new NotImplementedException();
        }
    }
}
