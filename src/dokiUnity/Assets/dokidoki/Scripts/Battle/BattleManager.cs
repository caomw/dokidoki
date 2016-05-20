using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

using SimpleJSON;
using dokidoki.dokiUnity;
using Debug = dokidoki.dokiUnity.Debug;

namespace dokidoki.dokiBattle {
    public class BattleManager : MonoBehaviour {
        public Dropdown redsDropdown;
        public Dropdown skillsDropdown;
        public Dropdown bluesDropdown;
        public Text battleLogText;

        public Battle battle;
        public Dictionary<string, BattleEquipment> equipments = new Dictionary<string, BattleEquipment>();
        public Dictionary<string, BattleSkill> skills = new Dictionary<string, BattleSkill>();
        public Dictionary<string, BattleCareer> careers = new Dictionary<string, BattleCareer>();
        public Dictionary<string, BattleCharacter> characters = new Dictionary<string, BattleCharacter>();
        public List<BattleCharacter> battleCharacters = new List<BattleCharacter>();
        public BattleCharacter focusedBattleCharacter;

        private bool isOK = false;

        private void AutoLoad(){
            Object[] skillCards = Resources.LoadAll(FolderStructure.BATTLE_CARDS + FolderStructure.BATTLE_SKILLS);
            Object[] careerCards = Resources.LoadAll(FolderStructure.BATTLE_CARDS + FolderStructure.BATTLE_CAREERS);
            Object[] equipmentCards = Resources.LoadAll(FolderStructure.BATTLE_CARDS + FolderStructure.BATTLE_EQUIPMENTS);
            Object[] characterCards = Resources.LoadAll(FolderStructure.BATTLE_CARDS + FolderStructure.BAtTLE_CHARACTERS);

            foreach(var skillCard in skillCards){
                var N = JSONNode.Parse(skillCard.ToString());
                Debug.Log("name: "+N[BattleConstants.NAME]);
                this.LoadSkill(N);
            }

            foreach (var careerCard in careerCards) {
                var N = JSONNode.Parse(careerCard.ToString());
                Debug.Log("name: " + N[BattleConstants.NAME]);
                this.LoadCareer(N);
            }

            foreach (var equipmentCard in equipmentCards) {
                var N = JSONNode.Parse(equipmentCard.ToString());
                Debug.Log("name: " + N[BattleConstants.NAME]);
                this.LoadEquipment(N);
            }

            foreach (var characterCard in characterCards) {
                var N = JSONNode.Parse(characterCard.ToString());
                Debug.Log("name: " + N[BattleConstants.NAME]);
                this.LoadCharacter(N);
            }
        }

        private void LoadEquipment(JSONNode N) {
            string id = N[BattleConstants.ID];
            string name = N[BattleConstants.NAME];
            float range = float.Parse(N[BattleConstants.RANGE]);
            Dictionary<string, float> abilitiesIncrement = this.GetDictionaryFloat((JSONClass)N.AsObject[BattleConstants.ABILITIES_INCREMENT]);
            BattleEquipment equipment = new BattleEquipment(id, name, range, abilitiesIncrement);
            equipments[id] = equipment;
        }

        private void LoadSkill(JSONNode N) {
            string id = N[BattleConstants.ID];
            string name = N[BattleConstants.NAME];
            Dictionary<string, string> cost = this.GetDictionary((JSONClass)N.AsObject[BattleConstants.COST]);
            float damageRange = float.Parse(N[BattleConstants.DAMAGE_RANGE]);
            Dictionary<string, string> damage = this.GetDictionary((JSONClass)N.AsObject[BattleConstants.DAMAGE]);
            int damageCharacterMaximum = int.Parse(N[BattleConstants.DAMAGE_CHARACTER_MAXIMUM]);
            float healRange = float.Parse(N[BattleConstants.HEAL_RANGE]);
            Dictionary<string, string> heal = this.GetDictionary((JSONClass)N.AsObject[BattleConstants.HEAL]);
            int healCharacterMaximum = int.Parse(N[BattleConstants.HEAL_CHARACTER_MAXIMUM]);
            BattleSkill skill = new BattleSkill(id, name, cost
                                                , damageRange, damage, damageCharacterMaximum
                                                , healRange, heal, healCharacterMaximum);
            skills[id] = skill;
        }

        public Dictionary<string, float> GetDictionaryFloat(JSONClass N) {
            Dictionary<string, string> d = this.GetDictionary(N);
            Dictionary<string, float> df = new Dictionary<string, float>();
            foreach(KeyValuePair<string, string> keyValuePair in d){
                df[keyValuePair.Key] = float.Parse(keyValuePair.Value);
            }
            return df;
        }

        public Dictionary<string, string> GetDictionary(JSONClass N) {
            Dictionary<string, string> d = new Dictionary<string, string>();
            foreach (string key in N.GetKeys()) {
                d.Add(key, N[key]);
            }
            return d;
        }

        public List<string> GetList(JSONNode N) {
            List<string> l = new List<string>();
            foreach(string value in N.Childs){
                l.Add(value);
            }
            return l;
        }

        private void LoadCareer(JSONNode N) {
            string id = N[BattleConstants.ID];
            string name = N[BattleConstants.NAME];
            List<string> skillIds = this.GetList(N[BattleConstants.SKILLS]);
            List<BattleSkill> careerSkills = new List<BattleSkill>();
            foreach(var skillId in skillIds){
                careerSkills.Add(skills[skillId]);
            }
            BattleCareer career = new BattleCareer(id, name, careerSkills);
            careers[id] = career;
        }

        private void LoadCharacter(JSONNode N) {
            string id = N[BattleConstants.ID];
            string name = N[BattleConstants.NAME];
            string role = N[BattleConstants.ROLE];
            string position = N[BattleConstants.POSITION];
            int level = int.Parse(N[BattleConstants.LEVEL]);
            float speed = float.Parse(N[BattleConstants.SPEED]);
            Dictionary<string, float> statuses = this.GetDictionaryFloat((JSONClass)N.AsObject[BattleConstants.STATUSES]);
            Dictionary<string, float> abilities = this.GetDictionaryFloat((JSONClass)N.AsObject[BattleConstants.ABILITIES]);
            List<string> careerIds = this.GetList(N[BattleConstants.CAREERS]);
            List<BattleCareer> characterCareers = new List<BattleCareer>();
            foreach(var careerId in careerIds){
                characterCareers.Add(careers[careerId]);
            }
            Dictionary<string, float> statusesLevelUpIncrement = this.GetDictionaryFloat((JSONClass)N.AsObject[BattleConstants.STATUSES_LEVEL_UP_INCREMENT]);
            Dictionary<string, float> abilitiesLevelUpIncrement = this.GetDictionaryFloat((JSONClass)N.AsObject[BattleConstants.ABILITIES_LEVEL_UP_INCREMENT]);
            List<string> equipmentIds = this.GetList(N[BattleConstants.EQUIPMENTS]);
            List<BattleEquipment> characterEquipments = new List<BattleEquipment>();
            foreach(var equipmentId in equipmentIds){
                characterEquipments.Add(equipments[equipmentId]);
            }
            BattleCharacter character = new BattleCharacter(id, name, role, new Vector3(), level, speed, statuses
                                                            , abilities, characterCareers, statusesLevelUpIncrement
                                                            , abilitiesLevelUpIncrement, equipments);
            characters[id] = character;
        }

        public void chooseBattleActionOptions() {
            List<BattleSkill> skills = this.focusedBattleCharacter.getSkills();
            skills.Sort();
            battleCharacters.Sort();

            BattleAction battleAction = new BattleAction();
            battleAction.sources.Add(this.focusedBattleCharacter);
            battleAction.skill = skills[skillsDropdown.value];

            //get the target character
            int targetCharacterIndex = -1;
            for (int i = 0; i < battleCharacters.Count; i++) {
                if (battleCharacters[i].role == BattleConstants.CHARACTER_ROLE_BLUE) {
                    targetCharacterIndex++;
                    if (targetCharacterIndex == bluesDropdown.value) {
                        battleAction.targets.Add(battleCharacters[i]);
                    }
                }
            }

            this.battle.continueBattle(battleAction);
            return;
        }

        public void updateBattleActionOptions(BattleCharacter battleCharacter) {
            this.focusedBattleCharacter = battleCharacter;

            if (focusedBattleCharacter.role == BattleConstants.CHARACTER_ROLE_BLUE) {
                BattleAction battleAction = new BattleAction();
                battleAction.sources.Add(focusedBattleCharacter);
                battleAction.skill = focusedBattleCharacter.getSkills()[0];

                int targetCharacterIndex = 0;
                for (int i = 0; i < battleCharacters.Count; i++) {
                    if (battleCharacters[i].role == BattleConstants.CHARACTER_ROLE_RED) {
                        targetCharacterIndex = i;
                        break;
                    }
                }
                battleAction.targets.Add(battleCharacters[targetCharacterIndex]);

                this.battle.continueBattle(battleAction);
                return;
            }

            List<BattleSkill> skills = this.focusedBattleCharacter.getSkills();
            skills.Sort();
            battleCharacters.Sort();

            redsDropdown.options.Clear();
            Dropdown.OptionData redCharactersOptionData = new Dropdown.OptionData();
            redCharactersOptionData.text = battleCharacter.name;
            redsDropdown.options.Add(redCharactersOptionData);

            skillsDropdown.options.Clear();
            for (int i = 0; i < skills.Count; i++) {
                Dropdown.OptionData skillOptionData = new Dropdown.OptionData();
                skillOptionData.text = skills[i].name;
                skillsDropdown.options.Add(skillOptionData);
            }

            bluesDropdown.options.Clear();
            for (int i = 0; i < battleCharacters.Count; i++) {
                if (battleCharacters[i].role == BattleConstants.CHARACTER_ROLE_BLUE) {
                    Dropdown.OptionData blueOptionData = new Dropdown.OptionData();
                    blueOptionData.text = battleCharacters[i].name;
                    bluesDropdown.options.Add(blueOptionData);
                }
            }
        }

        void Awake() {
            this.AutoLoad();
        }

        void Start() {
            foreach(KeyValuePair<string, BattleCharacter> keyValuePair in characters){
                this.battleCharacters.Add(keyValuePair.Value);
            }
            this.battle = new Battle(this, this.battleCharacters, BattleConstants.GOAL_KILL_ALL
                                 , BattleConstants.GOAL_NOT_KILLED_ALL, 3);
            this.battle.start();
        }

        void Update() {

        }

        public void log(string log) {
            battleLogText.text = log + "\n" + battleLogText.text;
        }
    }
}