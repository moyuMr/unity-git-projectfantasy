using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInputControl inputControl;
    private Rigidbody2D Rb;
    public Vector2 inputDirection;
    [Header("BasicForce")]
    // public float walkSpeed = 125;
    // public float runSpeed = 250;
    public float speed = 250;
    public float jumpforce = 10;

    private void Awake() {
        inputControl = new PlayerInputControl();
        Rb = GetComponent<Rigidbody2D>();

            inputControl.InGamePlay.Jump.started += Jump;

        
    }


    private void OnEnable() {
        inputControl.Enable();
    } 
    private void OnDisable() {
        inputControl.Disable();
    }
    private void Update() {
        inputDirection = inputControl.InGamePlay.Move.ReadValue<Vector2>();
        
        
    }
    private void FixedUpdate() {
        Move();
    }

    public void Move(){
        // if(math.abs(inputDirection.x) >= 0.6)
        //     speed = runSpeed;
        // else speed = walkSpeed;
        Rb.velocity = new Vector2(speed * Time.deltaTime * inputDirection.x, Rb.velocity.y);
       

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
}
