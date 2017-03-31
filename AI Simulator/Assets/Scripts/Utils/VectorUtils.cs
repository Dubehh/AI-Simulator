using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Utils {
    static class VectorUtils {
        public static float Vec3DistanceSq(Vector3 v1, Vector3 v2) {
            return (v1 - v2).sqrMagnitude;
        }
        public static Vector3 Sub(Vector3 v1, Vector3 v2) {
            var ret = new Vector3();
            ret.x = v1.x - v2.x;
            ret.y = v1.y - v2.y;
            ret.z = v1.z - v2.z;
            return ret;
        }
    }
}
