using Assets.Scripts.Utils;
using UnityEngine;

namespace Assets.Scripts.Agents.Behaviors {
    //public enum Deceleration {
    //    Slow = 3,
    //    Normal = 2,
    //    Fast = 1
    //}
    public class ArriveBehavior : AgentBehaviorBase {
        private readonly Vector3 _target;
        private readonly Deceleration _deceleration;

        public ArriveBehavior(AgentBase agent,Vector3 target, Deceleration deceleration) : base(agent)
        {
            _target = target;
            _deceleration = deceleration;
        }
        public override AgentTransformation Calculate() {
            var toTarget = _target - Agent.Object.transform.position;

            var distance = Vector3.Distance(_target, Agent.Object.transform.position);

            if (distance <= 0) return new AgentTransformation(Agent.Object.transform.position);

            const float deceleration = 0.3f;

            var speed = distance / (_deceleration.GetHashCode() * deceleration);

            speed = Min(speed, Agent.Speed);

            var desiredVelocity = toTarget * (speed / distance);

            var des = desiredVelocity - (Vector3)Agent.Object.GetComponent<Rigidbody2D>().velocity;
            return new AgentTransformation(des.normalized);
          
        }

        public float Min(float a, float b) {
            return a < b ? a : b;
        }


    }
}
