using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleController : MonoBehaviour {
    public List<BattleCharacter> battleCharacters;
    public string winGoal;
    public string loseGoal;

    public BattleController(List<BattleCharacter> battleCharacters, string winGoal, string loseGoal) {
        this.battleCharacters = battleCharacters;
        this.winGoal = winGoal;
        this.loseGoal = loseGoal;
    }

}
