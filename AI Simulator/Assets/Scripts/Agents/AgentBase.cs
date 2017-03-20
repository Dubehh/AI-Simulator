using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Object = System.Object;

namespace Assets.Scripts.Agents {

    public abstract class AgentBase {

        private static int _agents;
        
        public Sprite Sprite { get; private set; }
        public GameObject Object { get; private set; }
        public int ID { get; private set; }

        public float Speed { get; set; }
        public float Wear { get; set; }
        
        public AgentBehaviourBase Behaviour { get; set; }
        private readonly string _fileName;

        protected AgentBase(string filename) {
            _fileName = filename;
            ID = _agents;
            _agents++;
        }

        public void Initialize() {
            Sprite = SpriteManager.GetInstance().GetSprite(_fileName, "png");
            Object = new GameObject();
            Object.AddComponent<SpriteRenderer>();
            Object.GetComponent<SpriteRenderer>().sprite = Sprite;
            Object.name = "Agent '"+_fileName+"' "+ID;
            AgentManager.GetInstance().Agents.Add(this);
            Load();
        }

        public abstract void Load();
        public abstract void Update();
    }
}
