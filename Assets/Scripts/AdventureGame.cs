using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class AdventureGame : MonoBehaviour
{
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;
    private State state;    

    // Start is called before the first frame update
    void Start()
    {
        this.state = this.startingState;
        UpdateStateStoryText();
    }

    void UpdateStateStoryText()
    {        
        textComponent.text = state.GetStateStoryText();
    }

    // Update is called once per frame
    void Update()
    {
        ManageNextStates();
    }

    private void ManageNextStates()
    {
        var nextStates = state.GetNextStoryStates();

        if(Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Quitting!");
            Application.Quit();
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
}
