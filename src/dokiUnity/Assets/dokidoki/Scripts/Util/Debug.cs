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
		public static void CheckResources(string name, Sprite resource){
			if (!ON) { return; }
			Debug.CheckResources (name, resource, "Sprite");
		}
		public static void CheckResources(string name, AudioClip resource){
			if (!ON) { return; }
			Debug.CheckResources (name, resource, "AudioClip");
		}
#if UNITY_STANDALONE  || UNITY_EDITOR
		public static void CheckResources(string name, MovieTexture resource){
			if (!ON) { return; }
			Debug.CheckResources (name, resource, "MovieTexture");
		}
#endif
#if UNITY_IOS
#endif
#if UNITY_ANDROID
#endif
		public static void CheckResources(string name, Texture2D resource){
			if (!ON) { return; }
			Debug.CheckResources (name, resource, "Texture2D");
		}
		public static void CheckResources(string name, System.Object resource, string type){
			if(resource == null){
				Debug.LogError ("[dokidoki] Could not find "+type+": "+name);
				Application.Quit ();
			}
		}
    }
}