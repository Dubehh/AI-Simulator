namespace Assets.Scripts.Agents.Behaviours {
    public class DrivingBehaviour : AgentBehaviourBase {

        private float _speed;

        public DrivingBehaviour(AgentBase agent, float speed): base(agent) {
            _speed = speed;

        }

        public override AgentTransformation Calculate() {
            return new AgentTransformation();
            //return new Vector3(Random.Range(-.4f, .4f), Random.Range(-.4f, .4f));
        }
    }
}
