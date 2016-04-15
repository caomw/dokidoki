using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace dokiBattle {
    public class BattleTurn {
        public BattleManager battleManager;
        public List<BattleCharacter> battleCharacters;

        public List<BattleAction> battleActions = new List<BattleAction>();

        public BattleTurn(BattleManager battleManager, List<BattleCharacter> battleCharacters) {
            this.battleManager = battleManager;
            this.battleCharacters = battleCharacters;
        }

        public void start() {
            this.turn();
        }

        public void battlecry() {
        }

        public void turn() {
            battleActions.Sort();
            battleActions.Reverse();
            for (int i = 0; i < battleActions.Count; i++) {
                battleManager.log(battleActions[i].take());
            }
        }

        public void deathrattle() {
        }

        public BattleCharacter getNextNotActionedCharacter() {
            battleActions.Sort();
            battleActions.Reverse();

            BattleCharacter battleCharacter = null;
            for (int i = 0; i < battleCharacters.Count; i++) {
                battleCharacter = battleCharacters[i];
                for (int k = 0; k < this.battleActions.Count; k++) {

                    //battleManager.log("Has action: "+this.battleActions[k].toString());

                    if (this.battleActions[k].sources.Contains(battleCharacter)) {
                        //this character already in one action's sources
                        //means this character already choose action
                        battleCharacter = null;
                        break;
                    }
                }
                if (battleCharacter != null) {
                    //this character is not in any action's sources
                    break;
                }
            }
            return battleCharacter;
        }

        public void addBattleAction(BattleAction battleAction) {
            this.battleActions.Add(battleAction);
        }
    }
}