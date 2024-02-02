using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private void Awake() {
        anim = GetComponent<Animator>();
    }

    private void Update() {
        SetAnimator()
;    }
    public  void SetAnimator(){
        anim.SetFloat("velocityXabs", math.abs(GetComponent<Rigidbody2D>().velocity.x));
        anim.SetFloat("velocityY", GetComponent<Rigidbody2D>().velocity.y);
        anim.SetBool("isGround", GetComponent<PhysicsCheck>().isGround);
        anim.SetBool("isDead",GetComponent<PlayerController>().isDead);
        anim.SetBool("isAttack",GetComponent<PlayerController>().isAttack);
        // anim.SetInteger("attackCombo",GetComponent<PlayerController>().attackCounter);
    }

    public void PlayerHurt(){
        anim.SetTrigger("hurt");
        // Debug.Log("hurt Triggered");
    }

    public void PlayerAttack(){
        anim.SetTrigger("attack");
        // Debug.Log("attack Triggered");
    }

}
