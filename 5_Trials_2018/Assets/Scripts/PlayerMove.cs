﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour {

    Rigidbody2D rig;
    public float moveSpeed;
    public bool canMove;

    public Animator animator;

    public byte direction;
    //Direction uses an int value to determine which direction the player is facing
    // 0:   Up
    // 1:   Left
    // 2:   Down
    // 3:   Right

    void Start () {
        rig = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
        if (!canMove)
        {
            rig.velocity = new Vector3(0f, 0f, 0f);
            return;
        }
        MoveX();
        MoveY();
        //transform.rotation = Quaternion.Euler(0, 0, getDirectionAngle());
    }

    //Handles horizontal movement
    private void MoveX()
    {
        //Handles moving right
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            rig.velocity = new Vector3(moveSpeed, rig.velocity.y, 0f);
            SetDirection(3);
            animator.SetTrigger("Right");
        }
        //Handles moving left
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            rig.velocity = new Vector3(-moveSpeed, rig.velocity.y, 0f);
            SetDirection(1);
            animator.SetTrigger("Left");
        }
        else
        {
            rig.velocity = new Vector3(0f, rig.velocity.y, 0f);
        }
    }

    //Handles vertical movement
    private void MoveY()
    {
        //Handles moving up
        if (Input.GetAxisRaw("Vertical") > 0f)
        {
            rig.velocity = new Vector3(rig.velocity.x, moveSpeed, 0f);
            SetDirection(0);
            animator.SetTrigger("Back");
        }
        //Handles moving down
        else if (Input.GetAxisRaw("Vertical") < 0f)
        {
            rig.velocity = new Vector3(rig.velocity.x, -moveSpeed, 0f);
            SetDirection(2);
            animator.SetTrigger("Forward");
        }
        else
        {
            rig.velocity = new Vector3(rig.velocity.x, 0f, 0f);
        }
    }

    //Direction uses an int value to determine which direction the player is facing
    // 0:   Up
    // 1:   Left
    // 2:   Down
    // 3:   Right
    private void SetDirection(byte direction)
    {
        this.direction = direction;
    }

    //Returns the player's direction as an angle
    //Up:     0
    //Left:  90
    //Down:   180
    //Right:   270
    public float getDirectionAngle()
    {
        return 90 * direction;
    }
}
