using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Level;
using UnityEngine;
using Assets.Scripts.Agents.States;
using Assets.Scripts.Agents.Behaviours;

namespace Assets.Scripts.Agents {

    public abstract class AgentBase {
        private static int _agents;
        private float _speed;
        private readonly string _fileName;

        public Sprite Sprite { get; private set; }
        public GameObject Object { get; private set; }
        public TileLocation StartedAtTileLocation { get; set; }
        public TileLocation CurrentTileLocation { get; set; }        
        public readonly float WearDamage;
        public int ID { get; private set; }
        public float Wear { get; set; }
        public readonly float MinSpeed = 2f;
        public readonly float MaxSpeed;
        public string Name { get; private set; }
        
        public AgentBehaviourBase Behavior { get; set; }
        public StateMachine StateMachine { get; set; }
        public float Speed {
            get { return _speed * Time.deltaTime; }
            set { _speed = value; }
        }
        public int FinishedLaps { get; internal set; }

        protected AgentBase(string filename) : this(filename, 1.0f, 1.0f) {}
        protected AgentBase(string filename, float dmg, float maxSpeed) {
            WearDamage = dmg;
            MaxSpeed = maxSpeed;
            Speed = maxSpeed;
            _fileName = filename;
            ID = _agents;
            Name = "Agent " + ID;
            _agents++;
            StateMachine = new StateMachine(this);
           

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
            /* Assign default values */
            body.gravityScale = 0;
            renderer.sprite = Sprite;
            Object.transform.parent = AgentManager.GetInstance().Parent.transform;
            StartedAtTileLocation = loc;
            //Debug.Log("StartedAtTileLocation set, x:" + StartedAtTileLocation.X + "," + StartedAtTileLocation.Y);
            CurrentTileLocation = loc; 
            Object.transform.position = TileManager.GetInstance().Tiles[loc].Object.transform.position;
            Object.name = "Agent '"+_fileName+"' "+ID;
            AgentManager.GetInstance().Agents.Add(this);
            Load();
        }

        public abstract void Load();
        public abstract void Update();
    }
}
