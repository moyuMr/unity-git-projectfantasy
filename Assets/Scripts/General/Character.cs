using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Timeline;

public class Character : MonoBehaviour
{
    [Header("Character Attributes")]
    public float maxHealth;
    public float currentHealth;
    public bool isDead;
    [Header("Invulnerable Attributes")]
    public float invulnerableDuration;
    private float invulnerableCounter;
    public bool isInvulnerable;

    public UnityEvent<Transform> OnTakeDamage;
    public UnityEvent OnDeath;
    public UnityEvent<Character> OnHealthChange;

    private void Start() {
        currentHealth = maxHealth;
        OnHealthChange?.Invoke(this);
    }

    private void Update() {
        invulnerableCounter -= Time.deltaTime;
        if (invulnerableCounter<=0)
        {
            isInvulnerable = false;
        }
    }

    public void TakeDamage(Attack attacker){
        if (isInvulnerable)
        {
            return; 
        }
        if (currentHealth - attacker.damage > 0 )
        {          
            currentHealth -= attacker.damage;
            InvulnerableTrigger();
            OnTakeDamage?.Invoke(attacker.transform);

        }
        else{
            OnTakeDamage?.Invoke(attacker.transform);
            currentHealth = 0;
            OnDeath?.Invoke();
        }

        OnHealthChange?.Invoke(this);
    }
    /// <summary>
    /// 
    /// </summary>

    private void InvulnerableTrigger(){
        if(!isInvulnerable){
            isInvulnerable = true;
            invulnerableCounter = invulnerableDuration;
        }
    }


}
