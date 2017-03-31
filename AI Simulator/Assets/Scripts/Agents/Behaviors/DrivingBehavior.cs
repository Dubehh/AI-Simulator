using UnityEngine;

namespace Assets.Scripts.Agents.Behaviors {
    public class DrivingBehavior : AgentBehaviorBase {

        private float _speed;

        public DrivingBehavior(AgentBase agent, float speed): base(agent) {
            _speed = speed;

        }

        public override AgentTransformation Calculate() {
            return new AgentTransformation();
            //return new Vector3(Random.Range(-.4f, .4f), Random.Range(-.4f, .4f));
        }
    }
}
