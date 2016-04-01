using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class BattleAction : MonoBehaviour, IComparable<BattleAction> {
    public List<BattleCharacter> sources;
    public List<BattleCharacter> targets;
    public BattleSkill skill;

    public void take() { 
        //Take this action
    }

    public int CompareTo(BattleAction otherBattleAction) {
        float sourcesLowestSpeed = this.sources[0].speed;
        foreach(BattleCharacter source in sources){
            if (sourcesLowestSpeed > source.speed) {
                sourcesLowestSpeed = source.speed;
            }
        }
        float otherSourcesLowestSpeed = otherBattleAction.sources[0].speed;
        foreach (BattleCharacter source in otherBattleAction.sources) {
            if (otherSourcesLowestSpeed > source.speed) {
                otherSourcesLowestSpeed = source.speed;
            }
        }
        if (sourcesLowestSpeed > otherSourcesLowestSpeed) {
            return 1;
        } else if (sourcesLowestSpeed == otherSourcesLowestSpeed) {
            return 0;
        } else {
            return -1;
        }
    }
}
