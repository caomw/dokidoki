using UnityEngine;
using System.Collections;

namespace dokidoki.dokiUnity {
    public class Trajectory {
        public static float Gradual(float start, float end, float t, float T){
            return start + (end - start) * (t / T);
        }
        public static Vector3 Gradual(Vector3 start, Vector3 end, float t, float T) {
            return start + (end - start) * (t / T);
        }
        public static float Sin(float start, float end, float t, float T) {
            return start + (end - start) * (1f - Mathf.Cos(t / T * Mathf.PI)) / 2f;
        }
        public static Vector3 Sin(Vector3 start, Vector3 end, float t, float T) {
            return start + (end - start) * (1f - Mathf.Cos(t / T * Mathf.PI)) / 2f;
        }
    }
}
