using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace dokiBattle {
    public class BattleSkill : IComparable<BattleSkill> {
        public string id;

        public string name;
        public string type;

        public int levelLimit;
        public Dictionary<string, float> cost;
        public Dictionary<string, float> depend;

        public float damageRange;
        public int damageCharacterMaximum;
        public Dictionary<string, float> damage;
        public float healRange;
        public int healCharacterMaximum;
        public Dictionary<string, float> heal;

        public BattleSkill(string id, string name, Dictionary<string, float> cost
                           , Dictionary<string, float> damage
                           , int damageCharacterMaximum
                           , Dictionary<string, float> heal
                           , int healCharacterMaximum) {
            this.id = id;
            this.name = name;
            this.cost = cost;
            this.damage = damage;
            this.damageCharacterMaximum = damageCharacterMaximum;
            this.heal = heal;
            this.healCharacterMaximum = healCharacterMaximum;
        }

        public int CompareTo(BattleSkill otherBattleSkill) {
            return this.id.CompareTo(otherBattleSkill.id);
        }
    }
}