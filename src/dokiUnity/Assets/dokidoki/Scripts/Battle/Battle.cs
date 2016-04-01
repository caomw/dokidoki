using System.Collections;
using System.Collections.Generic;


public class Battle{
    public List<BattleCharacter> battleCharacters;
    public string winGoal;
    public string loseGoal;
    public int turnLimit;

    public BattleController battleController;

    public int currentTurn;

    public Battle(List<BattleCharacter> battleCharacters, string winGoal, string loseGoal, int turnLimit = 9999) {
        this.battleCharacters = battleCharacters;
        this.winGoal = winGoal;
        this.loseGoal = loseGoal;
        this.turnLimit = turnLimit;
    }

    public string take() {

        currentTurn = 0;
        while(currentTurn < turnLimit){
            BattleTurn battleTurn = new BattleTurn(battleCharacters);
            battleTurn.take();
            if(this.isWin()){
                return BattleConstants.RESULT_WIN;
            }else if(this.isLose()){
                return BattleConstants.RESULT_LOSE;
            }
            currentTurn++;
        }
        return BattleConstants.RESULT_WIN;
    }


    public bool isWin() {
        return false;
    }
    public bool isLose() {
        return false;
    }
}
