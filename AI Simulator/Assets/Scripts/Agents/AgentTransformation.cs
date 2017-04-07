using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Agents {
    /// <summary>
    /// Holds information regarding the position and rotation from an agent.
    /// This data is used to update, translate and rotate an agent.
    /// </summary>
    public struct AgentTransformation {
        public Quaternion? Rotation { get; set; }
        public Vector3? Position { get; set; }

        public AgentTransformation(Quaternion rotation, Vector3 position) : this() {
            Rotation = rotation;
            Position = position;

        }
        public AgentTransformation(Vector3 position) : this() {
            Position = position;
            Rotation = null;
        }
        public AgentTransformation(Quaternion rotation) : this() {
            Rotation = rotation;
            Position = null;

        }
    }
}
