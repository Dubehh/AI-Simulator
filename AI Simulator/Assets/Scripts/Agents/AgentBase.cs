using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Level;
using UnityEngine;

namespace Assets.Scripts.Agents {

    public abstract class AgentBase {

        private static int _agents;
        
        public Sprite Sprite { get; private set; }
        public GameObject Object { get; private set; }
        public TileLocation TileLocation { get; set; }
        public readonly float WearDamage;
        public int ID { get; private set; }
        public float Wear { get; set; }

        public AgentBehaviourBase Behavior { get; set; }

        private float _speed;
        private readonly string _fileName;
        
        protected AgentBase(string filename) : this(filename, 1.0f) {}
        protected AgentBase(string filename, float dmg) {
            WearDamage = 1.0f;
            _fileName = filename;
            ID = _agents;
            _agents++;
        }
        public float Speed {
            get { return _speed * Time.deltaTime; }
            set { _speed = value; }
        }

        public void Initialize() {
            Initialize(TileManager.GetInstance().OrderedTiles[TileType.Finish][0].TileLocation);
        }

        public void Initialize(TileLocation loc) {
            Sprite = SpriteManager.GetInstance().GetSprite(_fileName, "png");
            Object = new GameObject();
            /* Setup components */
            SpriteRenderer renderer = Object.AddComponent<SpriteRenderer>();
            Rigidbody2D body = Object.AddComponent<Rigidbody2D>();
            BoxCollider2D collider = Object.AddComponent<BoxCollider2D>();

            /* Assign default values */
            body.gravityScale = 0;
            renderer.sprite = Sprite;
            Object.transform.parent = AgentManager.GetInstance().Parent.transform;
            TileLocation = loc;
            Object.transform.position = TileManager.GetInstance().Tiles[loc].Object.transform.position;
            Object.name = "Agent '"+_fileName+"' "+ID;
            AgentManager.GetInstance().Agents.Add(this);
            Load();
        }

        public abstract void Load();
        public abstract void Update();
    }
}
