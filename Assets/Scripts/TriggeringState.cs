using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName ="Triggering State")]
public class TriggeringState : State
{
    [SerializeField] State connectedEvent;

    public void AffectConnectedEvent(bool newState)
    {
        connectedEvent.SetActive(newState);
    }
}
