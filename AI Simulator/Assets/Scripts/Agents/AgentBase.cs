using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Object = System.Object;

namespace Assets.Scripts.Agents {

    public abstract class AgentBase {

        public Sprite Sprite { get; private set; }
        public GameObject Object { get; private set; }
        public float Speed { get; set; }
        public float Wear { get; set; }
        
        public AgentBehaviorBase Behavior { get; set; }
        private readonly string _fileName;

        protected AgentBase(string filename) {
            _fileName = filename;
        }

        public void Initialize() {
            Sprite = SpriteManager.GetInstance().GetSprite(_fileName, "png");
            Object = new GameObject();
            Object.AddComponent<SpriteRenderer>();
            Object.GetComponent<SpriteRenderer>().sprite = Sprite;
            Object.AddComponent<Rigidbody2D>();
            Object.GetComponent<Rigidbody2D>().gravityScale = 0;
            AgentManager.GetInstance().Agents.Add(this);
            Load();
        }

        public abstract void Load();
        public abstract void Update();
    }
}
