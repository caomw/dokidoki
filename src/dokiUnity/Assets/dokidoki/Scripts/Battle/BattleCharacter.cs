using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace dokiBattle {
    public class BattleCharacter : IComparable<BattleCharacter> {
        public string id;

        public string name;
        public string role;

        public Vector3 position;
        public int level;
        public float speed;

        public Dictionary<string, float> statuses;
        public Dictionary<string, float> abilities;
        public List<BattleCareer> careers = new List<BattleCareer>();

        public Dictionary<string, float> statusesLevelUpIncrement;
        public Dictionary<string, float> abilitiesLeveUpIncrement;

        public BattleWeapon weapon;

        public BattleCharacter(string id, string name, string role
                               , Dictionary<string, float> statuses
                               , Dictionary<string, float> abilities
                               , BattleWeapon weapon) {
            this.id = id;
            this.name = name;
            this.role = role;
            this.statuses = statuses;
            this.abilities = abilities;
            this.weapon = weapon;
        }

        public int CompareTo(BattleCharacter otherBattleCharacter) {
            if (this.speed > otherBattleCharacter.speed) {
                return 1;
            } else if (this.speed == otherBattleCharacter.speed) {
                return 0;
            } else {
                return -1;
            }
        }

        public List<BattleSkill> getSkills() {
            List<BattleSkill> skills = new List<BattleSkill>();
            foreach (BattleCareer career in careers) {
                skills.AddRange(career.skills);
            }
            return skills;
        }

        public string takeBattleAction(BattleAction action) {
            string log = this.name + ": (";
            for (int i = 0; i < action.sources.Count; i++) {
                log += action.sources[i].name + " ";
            }
            log += ") take <" + action.skill.name + "> to (";
            for (int i = 0; i < action.targets.Count; i++) {
                log += action.targets[i].name + " ";
            }
            log += ")\n";
            Debug.Log(log);

            Dictionary<string, float> cost = action.skill.cost;
            if (cost == null) {
                return log;
            }
            foreach (KeyValuePair<string, float> costKeyValuePair in cost) {
                if (this.statuses[costKeyValuePair.Key] < costKeyValuePair.Value) {
                    return null;
                } else {
                    this.statuses[costKeyValuePair.Key] -= costKeyValuePair.Value;
                }
            }

            return log;
        }

        public string receiveBattleAction(BattleAction action) {
            string log = this.name + ": (";
            for (int i = 0; i < action.targets.Count; i++) {
                log += action.targets[i].name + " ";
            }

            log += ") receive <" + action.skill.name + "> from (";
            for (int i = 0; i < action.sources.Count; i++) {
                log += action.sources[i].name + " ";
            }
            log += ")\n";
            Debug.Log(log);

            Dictionary<string, float> damage = action.skill.damage;
            if (damage == null) {
                return null;
            }
            foreach (KeyValuePair<string, float> damageKeyValuePair in damage) {

                if (this.statuses[damageKeyValuePair.Key] < damageKeyValuePair.Value) {
                    this.statuses[damageKeyValuePair.Key] = 0f;
                } else {
                    this.statuses[damageKeyValuePair.Key] -= damageKeyValuePair.Value;
                }
            }

            log = this.name + "'s HP = " + this.statuses["HP"] + "\n" + log;

            if (this.statuses["HP"] <= 0f) {
                log = this.name + " dead. \n" + log;
            }

            return log;
        }

        public BattleWeapon setWeapon(BattleWeapon weapon) {
            BattleWeapon oldWeapon = this.weapon;
            this.weapon = weapon;
            return oldWeapon;
        }
        public void addCareer(BattleCareer career) {
            this.careers.Add(career);
        }
    }
}