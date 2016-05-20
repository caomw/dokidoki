using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace dokidoki.dokiBattle {
    public class BattleSkill : IComparable<BattleSkill> {
        public string id;

        public string name;
        public string type;

        public int levelLimit;
        public Dictionary<string, string> cost;

        public float damageRange;
        public int damageCharacterMaximum;
        public Dictionary<string, string> damage;
        public float healRange;
        public int healCharacterMaximum;
        public Dictionary<string, string> heal;

        public BattleSkill(string id, string name, Dictionary<string, string> cost
                           , float damageRange
                           , Dictionary<string, string> damage
                           , int damageCharacterMaximum
                           , float healRange
                           , Dictionary<string, string> heal
                           , int healCharacterMaximum) {
            this.id = id;
            this.name = name;
            this.cost = cost;
            this.damageRange = damageRange;
            this.damage = damage;
            this.damageCharacterMaximum = damageCharacterMaximum;
            this.healRange = healRange;
            this.heal = heal;
            this.healCharacterMaximum = healCharacterMaximum;
        }

        public int CompareTo(BattleSkill otherBattleSkill) {
            return this.id.CompareTo(otherBattleSkill.id);
        }
    }
}