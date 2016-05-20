using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace dokidoki.dokiBattle {
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

        public Dictionary<string, BattleEquipment> equipments;

        public BattleCharacter(string id, string name, string role
                               , Vector3 position
                               , int level
                               , float speed
                               , Dictionary<string, float> statuses
                               , Dictionary<string, float> abilities
                               , List<BattleCareer> careers
                               , Dictionary<string, float> statusesLevelUpIncrement
                               , Dictionary<string, float> abilitiesLeveUpIncrement
                               , Dictionary<string, BattleEquipment> equipments) {
            this.id = id;
            this.name = name;
            this.role = role;
            this.position = position;
            this.level = level;
            this.speed = speed;
            this.statuses = statuses;
            this.abilities = abilities;
            this.careers = careers;
            this.statusesLevelUpIncrement = statusesLevelUpIncrement;
            this.abilitiesLeveUpIncrement = abilitiesLeveUpIncrement;
            this.equipments = equipments;
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

            Dictionary<string, string> cost = action.skill.cost;
            if (cost == null) {
                return log;
            }
            foreach (KeyValuePair<string, string> costKeyValuePair in cost) {
                
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

            Dictionary<string, string> damage = action.skill.damage;
            if (damage == null) {
                return null;
            }
            foreach (KeyValuePair<string, string> damageKeyValuePair in damage) {
                
            }

            log = this.name + "'s HP = " + this.statuses["HP"] + "\n" + log;

            if (this.statuses["HP"] <= 0f) {
                log = this.name + " dead. \n" + log;
            }

            return log;
        }

        public BattleEquipment SetEquipment (string position, BattleEquipment equipment) {
            BattleEquipment oldEquipment = null;
            if(this.equipments.TryGetValue(position, out oldEquipment)){
                
            }
            this.equipments[position] = equipment;
            return oldEquipment;
        }

        public void addCareer(BattleCareer career) {
            this.careers.Add(career);
        }
    }
}