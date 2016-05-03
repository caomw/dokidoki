using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace dokidoki.dokiBattle {
    public class BattleCareer {
        public string id;

        public string name;
        public List<BattleSkill> skills = new List<BattleSkill>();

        public BattleCareer(string id, string name) {
            this.id = id;
            this.name = name;
        }

        public void addSkill(BattleSkill skill) {
            this.skills.Add(skill);
        }
    }
}
