using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    [TextArea(10, 14)] [SerializeField] string stateStoryText;
    [SerializeField] List<String> optionsText;
    [SerializeField] State[] nextStoryStates;
    [SerializeField] bool active = true;
    
    public string GetStateStoryText()
    {
        return this.stateStoryText;
    }

    public List<String> GetOptionsText()
    {
        return optionsText;
    }

    public State[] GetNextStoryStates()
    {
        return this.nextStoryStates;
    }    

    public void SetActive(bool newValue)
    {
        active = newValue;
    }

    public bool IsActive()
    {
        return active;
    }
}
