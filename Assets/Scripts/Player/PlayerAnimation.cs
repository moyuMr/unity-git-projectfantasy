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
    }

}
