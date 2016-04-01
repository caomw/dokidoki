using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleSkill: MonoBehaviour{
    public string name;
    public string type;

    public int levelLimit;
    public Dictionary<string, float> cost;
    public Dictionary<string, float> depend;

    public float damageRange;
    public int damageCharacterMaximum;
    public Dictionary<string, float> damage;
    public float healRange;
    public int healCharacterMaximum;
    public Dictionary<string, float> heal;
}
