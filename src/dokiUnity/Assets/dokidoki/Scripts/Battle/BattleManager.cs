using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour {
	public Dropdown redsDropdown;
	public Dropdown skillsDropdown;
	public Dropdown bluesDropdown;
	public Text battleLogText;

	public Battle battle;
	public List<BattleWeapon> battleWeapons = new List<BattleWeapon>();
	public List<BattleSkill> battleSkills = new List<BattleSkill>();
	public List<BattleCareer> battleCareers = new List<BattleCareer> ();
	public List<BattleCharacter> battleCharacters = new List<BattleCharacter>();
	public BattleCharacter focusedBattleCharacter;

	private bool isOK = false;

	public void loadWeapons(){
		BattleWeapon weapon0 = new BattleWeapon ("weapon0", "hand", 0f
		                                         , null);
		battleWeapons.Add (weapon0);
	}

	public void loadSkills(){
		Dictionary<string, float> skill0Damage = new Dictionary<string, float>();
		skill0Damage.Add ("HP", 1f);
		BattleSkill skill0 = new BattleSkill ("skill0", "bite", null, skill0Damage, 1
		                                      ,null, 0);

		BattleSkill skill1 = new BattleSkill ("skill1", "sleep", null, null, 0
		                                      ,null, 0);
        Dictionary<string, float> skill1Damage = new Dictionary<string, float>();
        skill1Damage.Add("HP", 2f);
        BattleSkill skill2 = new BattleSkill("skill2", "superpower", null, skill1Damage, 1
                                              , null, 0);
		battleSkills.Add (skill0);
		battleSkills.Add (skill1);
        battleSkills.Add(skill2);
	}

	public void loadCareers(){
		BattleCareer career0 = new BattleCareer ("career0", "creature");
		career0.addSkill (battleSkills[0]);
		career0.addSkill (battleSkills[1]);
        career0.addSkill(battleSkills[2]);
		battleCareers.Add (career0);
	}

	public void loadCharacters(){
		Dictionary<string, float> meStatuses = new Dictionary<string, float> ();
		meStatuses.Add ("HP", 5f);
		BattleCharacter me = new BattleCharacter ("character0", "me"
		                                          , BattleConstants.CHARACTER_ROLE_RED
		                                          , meStatuses, null, battleWeapons[0]);
		me.addCareer (battleCareers[0]);

		Dictionary<string, float> me2Statuses = new Dictionary<string, float> ();
        me2Statuses.Add("HP", 5f);
		BattleCharacter me2 = new BattleCharacter ("character1", "you"
                                                  , BattleConstants.CHARACTER_ROLE_RED
                                                  , me2Statuses, null, battleWeapons[0]);
        me2.addCareer(battleCareers[0]);

        Dictionary<string, float> suraimuStatuses = new Dictionary<string, float>();
        suraimuStatuses.Add("HP", 3f);
        BattleCharacter suraimu = new BattleCharacter("character1", "suraimu"
                                                  , BattleConstants.CHARACTER_ROLE_BLUE
                                                  , suraimuStatuses, null, battleWeapons[0]);
        suraimu.addCareer(battleCareers[0]);

		battleCharacters.Add (me);
		battleCharacters.Add (suraimu);
	}

	public void chooseBattleActionOptions() {
		List<BattleSkill> skills = this.focusedBattleCharacter.getSkills ();
		skills.Sort ();
		battleCharacters.Sort ();

		BattleAction battleAction = new BattleAction();
		battleAction.sources.Add (this.focusedBattleCharacter);
		battleAction.skill = skills [skillsDropdown.value];

		//get the target character
		int targetCharacterIndex = -1;
		for(int i=0; i<battleCharacters.Count;i++){
			if(battleCharacters[i].role == BattleConstants.CHARACTER_ROLE_BLUE){
				targetCharacterIndex++;
				if(targetCharacterIndex == bluesDropdown.value){
					battleAction.targets.Add (battleCharacters [i]);
				}
			}
		}

		this.battle.continueBattle(battleAction);
		return;
	}

	public void updateBattleActionOptions(BattleCharacter battleCharacter){
		this.focusedBattleCharacter = battleCharacter;
		//this.log ("focus = " + this.focusedBattleCharacter.name);

		if(focusedBattleCharacter.role == BattleConstants.CHARACTER_ROLE_BLUE){
			BattleAction battleAction = new BattleAction();
			battleAction.sources.Add(focusedBattleCharacter);
			battleAction.skill = focusedBattleCharacter.getSkills()[0];

			int targetCharacterIndex = 0;
			for(int i=0;i<battleCharacters.Count;i++){
				if(battleCharacters[i].role == BattleConstants.CHARACTER_ROLE_RED){
					targetCharacterIndex = i;
					break;
				}
			}
			battleAction.targets.Add(battleCharacters[targetCharacterIndex]);

			this.battle.continueBattle(battleAction);
			return;
		}

		List<BattleSkill> skills = this.focusedBattleCharacter.getSkills ();
		skills.Sort ();
		battleCharacters.Sort ();

		redsDropdown.options.Clear();
		Dropdown.OptionData redCharactersOptionData = new Dropdown.OptionData ();
		redCharactersOptionData.text = battleCharacter.name;
		redsDropdown.options.Add (redCharactersOptionData);
		
		skillsDropdown.options.Clear ();
		for(int i=0; i<skills.Count ;i++){
			Dropdown.OptionData skillOptionData = new Dropdown.OptionData ();
			skillOptionData.text = skills[i].name;
			skillsDropdown.options.Add(skillOptionData);
		}
		
		bluesDropdown.options.Clear ();
		for(int i=0; i<battleCharacters.Count; i++){
			if(battleCharacters[i].role == BattleConstants.CHARACTER_ROLE_BLUE){
				Dropdown.OptionData blueOptionData = new Dropdown.OptionData ();
				blueOptionData.text = battleCharacters[i].name;
				bluesDropdown.options.Add(blueOptionData);
			}
		}
	}

	void Awake(){
		loadWeapons ();
		loadSkills ();
		loadCareers ();
		loadCharacters ();
	}

	void Start(){
		this.battle = new Battle (this, this.battleCharacters, BattleConstants.GOAL_KILL_ALL
		                     ,BattleConstants.GOAL_NOT_KILLED_ALL, 9999);
		this.battle.start ();
	}

	void Update(){

	}

	public void log(string log){
		battleLogText.text = log + "\n" + battleLogText.text;
	}
}
