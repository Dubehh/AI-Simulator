using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Level {
    public struct WorldSize
    {
        public float Width { get;  private set; }
        public float Height { get; private set; }

        public WorldSize(float width, float height)
        {
            Width = width;
            Height = height;
        }
    }
}
