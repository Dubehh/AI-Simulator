using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts {
    public class SpriteManager {

        private static SpriteManager _instance;
        private readonly Dictionary<string, Sprite> _spriteRegister;
        private readonly string _spritePath;

        private SpriteManager() {
            _spriteRegister = new Dictionary<string, Sprite>();
            _spritePath = "Assets/Sprites/";
        }

        public static SpriteManager GetInstance() {
            return _instance ?? (_instance = new SpriteManager());
        }

        public Sprite GetSprite(string name, string extension) {
            if (!_spriteRegister.ContainsKey(name)) {
                var obj = AssetDatabase.LoadAssetAtPath(_spritePath + name + "." + extension, typeof(Sprite));
                _spriteRegister[name] = (Sprite)obj;
            }
            return _spriteRegister[name];
        }
    }
}
