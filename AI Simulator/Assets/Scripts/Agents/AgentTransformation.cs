using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Agents {
    public struct AgentTransformation {
        public Quaternion? Rotation { get; set; }
        public Vector3? Position { get; set; }

        public AgentTransformation(Quaternion rotation, Vector3 position) {
            Rotation = rotation;
            Position = position;

        }
        public AgentTransformation(Vector3 position) {
            Position = position;
            Rotation = null;
        }
        public AgentTransformation(Quaternion rotation) {
            Rotation = rotation;
            Position = null;

        }
    }
}
