using System;
using System.Collections;
using System.Collections.Generic;

public class BattleCharacter : IComparable<BattleCharacter> {
    public string name;
    public string role;

    public int level;
    public float speed;

	public Dictionary<string, float> statuses;
    public Dictionary<string, float> abilities;
    public List<BattleCareer> careers;

    public Dictionary<string, float> statusesLevelUpIncrement;
    public Dictionary<string, float> abilitiesLeveUpIncrement;

    public BattleWeapon battleWeapon;

    public int CompareTo(BattleCharacter otherBattleCharacter) {
        if (this.speed > otherBattleCharacter.speed) {
            return 1;
        } else if (this.speed == otherBattleCharacter.speed) {
            return 0;
        } else {
            return -1;
        }
    }
}
