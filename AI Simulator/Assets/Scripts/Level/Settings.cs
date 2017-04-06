using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Level {
    public enum Direction {
        Up,
        Down,
        Left,
        Right
    }
    public static class Settings {
        public static Direction StartFromFinish = Direction.Right;
    }
}
