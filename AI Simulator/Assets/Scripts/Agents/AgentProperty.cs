using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Agents {

    public class AgentProperty : MonoBehaviour {

        [SerializeField]
        public float Wear { get; set; }
        private float _speed;

        [SerializeField]
        public float Speed {
            get { return _speed; }
            set { this._speed = value * Time.deltaTime; }
        }

        public AgentProperty() : this(1f, 0f) { }
        public AgentProperty(float wear, float speed) {
            Wear = wear;
            Speed = speed;
        }
    }
}
