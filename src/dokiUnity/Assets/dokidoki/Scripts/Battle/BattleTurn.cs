using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleTurn : MonoBehaviour {
    public List<BattleCharacter> battleCharacters;

    public List<BattleAction> battleActions;

    public BattleTurn(List<BattleCharacter> battleCharacters) {
        this.battleCharacters = battleCharacters;
    }

    public void take() {

        battleCharacters.Sort();
        for (int i = battleCharacters.Count; i > 0;i-- ) {
            BattleAction battleAction;
            if (battleCharacters[i-1].role == BattleConstants.CHARACTER_ROLE_RED) {
                battleAction = waitForChooseAction(battleCharacters[i - 1]);
            }else{
                battleAction = new BattleAction();
            }
            battleActions.Add(battleAction);
        }

        this.turn();
    }

    public BattleAction waitForChooseAction(BattleCharacter battleCharacter) {
        BattleAction battleAction = new BattleAction();
        //Here waits for player to choose action to take for each character
        return battleAction;
    }

    public void battlecry() { 
        
    }

    public void turn() {
        battleActions.Sort();
        battleActions.Reverse();
        for (int i = 0; i < battleActions.Count; i++) {
            battleActions[i].take();
        }
    }

    public void deathrattle() { 
    
    }
}
