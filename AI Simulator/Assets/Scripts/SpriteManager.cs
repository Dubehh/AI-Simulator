using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;

namespace Assets.Scripts {
    public class SpriteManager {

        private static SpriteManager _instance;
        private readonly Dictionary<string, Sprite> _spriteRegister;
        private readonly string _spritePath;

        private SpriteManager() {
            _spriteRegister = new Dictionary<string, Sprite>();
            _spritePath = "Sprites/";
        }

        public static SpriteManager GetInstance() {
            return _instance ?? (_instance = new SpriteManager());
        }

        public Sprite GetSprite(string name, string extension) {
            if (!_spriteRegister.ContainsKey(name)) {
                //var obj = AssetDatabase.LoadAssetAtPath(_spritePath + name + "." + extension, typeof(Sprite));
                Debug.Log(name);
                var obj = Resources.Load<Sprite>(_spritePath + name);
                _spriteRegister[name] = obj;
            }
            return _spriteRegister[name];
        }
    }
}
