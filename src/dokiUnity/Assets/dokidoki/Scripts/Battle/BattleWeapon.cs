using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace dokidoki.dokiBattle {
    public class BattleWeapon : MonoBehaviour {
        public string id;

        public string name;
        public float range;
        public Dictionary<string, float> abilitiesIncrement;

        public BattleWeapon(string id, string name, float range
                            , Dictionary<string, float> abilitiesIncrement) {
            this.id = id;
            this.name = name;
            this.range = range;
            this.abilitiesIncrement = abilitiesIncrement;
        }
    }
}
