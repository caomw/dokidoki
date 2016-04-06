using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Battle{
	public BattleManager battleManager;
    public List<BattleCharacter> battleCharacters;
    public string winGoal;
    public string loseGoal;
	public string result;

    public int turnLimit;

	public List<BattleTurn> battleTurns = new List<BattleTurn>();

	public Battle(BattleManager battleManager, List<BattleCharacter> battleCharacters
	              ,string winGoal, string loseGoal, int turnLimit = 9999) {
		this.battleManager = battleManager;
        this.battleCharacters = battleCharacters;
        this.winGoal = winGoal;
        this.loseGoal = loseGoal;
        this.turnLimit = turnLimit;
    }

    public void start() {
		string log = "battle: (";
		for(int i=0;i<battleCharacters.Count;i++){
            log += battleCharacters[i].name + "(HP:" + battleCharacters[i].statuses["HP"]+")  ";
		}
		log += ")";
		battleManager.log (log);

		BattleTurn battleTurn = new BattleTurn(battleManager, battleCharacters);
		battleTurns.Add (battleTurn);
		battleManager.log ("Turn: "+battleTurns.Count);

		this.continueBattle (null);
    }

	public void continueBattle(BattleAction battleAction){
		if(battleAction != null){
			battleTurns[battleTurns.Count - 1].addBattleAction (battleAction);
		}
		BattleCharacter nextNotActionedCharacter = battleTurns[battleTurns.Count-1].getNextNotActionedCharacter ();
		if(nextNotActionedCharacter == null){
			//no next character
			//means all characters already choose actions, start this turn
			battleTurns[battleTurns.Count - 1].start();
			//judge the result of this battle
			if(this.isWin()){
				this.result = BattleConstants.RESULT_WIN;
				battleManager.log(result);
			}else if(this.isLose()){
				this.result = BattleConstants.RESULT_LOSE;
				battleManager.log(result);
			}
			//Enter next turn
			BattleTurn battleTurn = new BattleTurn(battleManager, battleCharacters);
			battleTurns.Add (battleTurn);
			battleManager.log ("Turn: "+battleTurns.Count+"\n\n");
			//get new next character
			nextNotActionedCharacter = battleTurns[battleTurns.Count-1].getNextNotActionedCharacter ();
		}
		battleManager.updateBattleActionOptions (nextNotActionedCharacter);
	}

	public bool isWin(){
		for(int i=0; i<battleCharacters.Count;i++){
			if(battleCharacters[i].role == BattleConstants.CHARACTER_ROLE_BLUE
			   && battleCharacters[i].statuses["HP"]>0f){
				return false;
			}
		}
		return true;
	}

	public bool isLose(){
		for(int i=0; i<battleCharacters.Count;i++){
			if(battleCharacters[i].role == BattleConstants.CHARACTER_ROLE_RED
			   && battleCharacters[i].statuses["HP"] <= 0f){
				return true;
			}
		}
		return false;
	}

	public string getResult(){
		return this.result;
	}
}
