using System;
using System.Collections;
using System.Collections.Generic;

namespace dokidoki.dokiBattle {
    public class BattleAction : IComparable<BattleAction> {
        public List<BattleCharacter> sources = new List<BattleCharacter>();
        public List<BattleCharacter> targets = new List<BattleCharacter>();
        public BattleSkill skill;

        public string take() {
            string log = "";
            foreach (BattleCharacter source in this.sources) {
                log = source.takeBattleAction(this) + log;
            }
            foreach (BattleCharacter target in this.targets) {
                log = target.receiveBattleAction(this) + log;
            }
            return log;
        }

        public string toString() {
            string log = "(";
            for (int i = 0; i < this.sources.Count; i++) {
                log += this.sources[i].name + " ";
            }
            log += ") <" + this.skill.name + "> (";
            for (int i = 0; i < this.targets.Count; i++) {
                log += this.targets[i].name + " ";
            }
            log += ")\n";
            return log;
        }

        public int CompareTo(BattleAction otherBattleAction) {
            float sourcesLowestSpeed = this.sources[0].speed;
            foreach (BattleCharacter source in sources) {
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
}