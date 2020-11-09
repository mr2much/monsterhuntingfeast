using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{    
    [TextArea(10,14)][SerializeField] string stateStoryText;
    [SerializeField] State[] nextStoryStates;    

    public string GetStateStoryText()
    {
        return this.stateStoryText;
    }

    public State[] GetNextStoryStates()
    {
        return this.nextStoryStates;
    }
}
