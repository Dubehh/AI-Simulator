using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Agents {

    public abstract class AgentBase {

        private static int _agents;
        
        public Sprite Sprite { get; private set; }
        public GameObject Object { get; private set; }
        public int ID { get; private set; }

        public AgentBehaviorBase Behavior { get; set; }
        public AgentProperty Property { get; set; }
        private readonly string _fileName;
        
        protected AgentBase(string filename) {
            _fileName = filename;
            ID = _agents;
            _agents++;
        }

        protected AgentBase(string filename, float speed, float wear) : this(filename) {
            Property = new AgentProperty(wear, speed);
        }

        public void Initialize() {
            Initialize(new Vector3(0, 0, 0));
        }

        public void Initialize(Vector3 location) {
            Sprite = SpriteManager.GetInstance().GetSprite(_fileName, "png");
            Object = new GameObject();
            SpriteRenderer renderer = Object.AddComponent<SpriteRenderer>();
            Rigidbody2D body = Object.AddComponent<Rigidbody2D>();
            body.gravityScale = 0;
            renderer.sprite = Sprite;
            Object.transform.parent = AgentManager.GetInstance().Parent.transform;
            Object.transform.position = location;
            Object.name = "Agent '"+_fileName+"' "+ID;
            AgentManager.GetInstance().Agents.Add(this);
            Load();
        }

        public abstract void Load();
        public abstract void Update();
    }
}
