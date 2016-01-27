using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Action{
    public readonly string tag;
    public readonly Dictionary<string, string> parameters;

    public Action(string tag, Dictionary<string, string> parameters) {
        this.tag = tag;
        this.parameters = parameters;
    }
}
