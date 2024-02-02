using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D Rb;
    private CapsuleCollider2D capColl;
    public PlayerInputControl inputControl;
    public Vector2 inputDirection;
    public PlayerAnimation playerAnim;
    [Header("BasicForce")]
    // public float walkSpeed = 125;
    // public float runSpeed = 250;
    public float speed = 250;
    public float jumpforce = 10;
    public float hurtForce; 

    [Header("State")]
    public bool isHurt;
    public bool isDead;
    public bool isAttack;
    // public int attackCounter;

    [Header("Material")]
    public PhysicsMaterial2D normal;
    public PhysicsMaterial2D noFriction;

    private void Awake() {
        capColl = GetComponent<CapsuleCollider2D>();
        Rb = GetComponent<Rigidbody2D>();
        inputControl = new PlayerInputControl();
        playerAnim = GetComponent<PlayerAnimation>();

        inputControl.InGamePlay.Jump.started += Jump;
        inputControl.InGamePlay.Attack.started += PlayerAttack;

        
    }


    private void OnEnable() {
        inputControl.Enable();
    } 
    private void OnDisable() {
        inputControl.Disable();
    }
    private void Update() {
        inputDirection = inputControl.InGamePlay.Move.ReadValue<Vector2>();
        CheckState();
    }
    private void FixedUpdate() {
        if (isHurt)
        {
            return;
        }
        Move();
        Debug.Log("moving");    
        {
            
        }
    }

    public void Move(){
        // if(math.abs(inputDirection.x) >= 0.6)
        //     speed = runSpeed;
        // else speed = walkSpeed;
        if (isAttack)
        {
            Rb.velocity = new Vector2(0, Rb.velocity.y);
            
        }
        else{
            Rb.velocity = new Vector2(speed * Time.deltaTime * inputDirection.x, Rb.velocity.y);
        }

        //character Flip人物翻转

        //初始化时继承原值，
        int faceDir = (int)transform.localScale.x;
        if(inputDirection.x > 0)
            faceDir = 1;
        if(inputDirection.x < 0)
            faceDir = -1;
        transform.localScale = new Vector3(faceDir, 1 , 1); 
    }
    private void Jump(InputAction.CallbackContext context)
    {
         if (GetComponent<PhysicsCheck>().isGround)
        {
        // Debug.Log("JumpPressed");
        Rb.AddForce(jumpforce * transform.up,ForceMode2D.Impulse);
        }
    }

    private void PlayerAttack(InputAction.CallbackContext context)
    {
        playerAnim.PlayerAttack();
        isAttack = true;
        // attackCounter++;
        // if(attackCounter >= 3)
        //     attackCounter = 0;
    }


    #region UnityEvent
    public void GetHurt(Transform attacker){
        isHurt = true;
        Rb.velocity = Vector2.zero;
        Vector2 dir = new Vector2(transform.position.x - attacker.position.x , 0).normalized;
        Rb.AddForce(hurtForce * dir,ForceMode2D.Impulse);
    }

    public void PlayerDead(){
        isDead = true;
        inputControl.InGamePlay.Disable();
    }
    #endregion

    private void CheckState(){
        capColl.sharedMaterial = GetComponent<PhysicsCheck>().isGround?normal:noFriction;
    }
}
