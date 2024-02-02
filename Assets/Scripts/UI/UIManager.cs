using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public PlayerStateBar playerStateBar;
    [Header("EventsListen")]
    public CharacterEventSO healthEvent;

    private void OnEnable() {
        healthEvent.OnEventRaised += OnHealthEvent;
    }


    private void OnDisable() {
        healthEvent.OnEventRaised -= OnHealthEvent;
        
    }
    private void OnHealthEvent(Character character)
    {
        var persentage = character.currentHealth/character.maxHealth;
        playerStateBar.OnHealthChange(persentage);
    }
}
