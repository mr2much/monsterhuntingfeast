using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class AdventureGame : MonoBehaviour
{
    class Choice
    {
        internal string description;
        internal State state;

        public Choice(string description, State state)
        {
            this.description = description;
            this.state = state;
        }
    }

    [SerializeField] Text textComponent;
    [SerializeField] State startingState;
    private Dictionary<int, Choice> options = new Dictionary<int, Choice>();
    private State state;    

    // Start is called before the first frame update
    void Start()
    {
        this.state = this.startingState;
        UpdateStateStoryText();
    }

    void UpdateStateStoryText()
    {
        options.Clear();
        textComponent.text = state.GetStateStoryText();

        // Set available choices
        SetAvailableChoices();

        // Show available choices
        DisplayChoices();
    }

    // Update is called once per frame
    void Update()
    {
        ManageNextStates();
    }

    private void ManageNextStates()
    {        
        var nextStates = state.GetNextStoryStates();        

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Quitting!");            
        } else
        {
            for (var i = 0; i < nextStates.Length; i++)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1 + i) ||
                  (Input.GetKeyDown(KeyCode.Keypad1 + i)))
                {
                    state = nextStates[i];
                    UpdateStateStoryText();
                    break;
                }
            }
        }        
    }

    private void SetAvailableChoices()
    {       
        var newIndex = 0;

        for (var i = 0; i < state.GetNextStoryStates().Length; i++)
        {
            State nextState = state.GetNextStoryStates()[i];

            // get active state
            if (nextState.IsActive())
            {
                if(!options.ContainsKey(newIndex))
                {
                    var description = this.state.GetOption(i);
                    options.Add(newIndex, new Choice(description, nextState));
                    newIndex++;
                }                

                //newIndex++;
            }
        }          
    }

    private void DisplayChoices()
    {   
        foreach(var item in options)
        {
            var choiceIndex = item.Key + 1;
            var choice = item.Value;

            this.textComponent.text += "\n" + choiceIndex + ". " + choice.description;
        }
    }    
}
