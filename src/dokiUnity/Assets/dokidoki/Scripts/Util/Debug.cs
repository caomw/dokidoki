using UnityEngine;
using System.Collections;

namespace dokiUnity {
    /// <summary>
    /// Debug is a wrapper of UnityEngine.Debug
    /// </summary>
    public class Debug{
        public const bool ON = true;

        public static void Log(System.Object message){
            if (!ON) { return; }
            UnityEngine.Debug.Log(message);
        }
        public static void LogError(System.Object message) {
            if (!ON) { return; }
            UnityEngine.Debug.LogError(message);
        }
    }
}