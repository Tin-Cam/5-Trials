﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour {

    Rigidbody2D rig;
    public float moveSpeed;
    public bool canMove;

    Animator animator;

    public byte direction;
    //Direction uses an int value to determine which direction the player is facing
    // 0:   Right
    // 1:   Down
    // 2:   Left
    // 3:   Up

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
	}

    //Handles horizontal movement
    private void MoveX()
    {
        //Handles moving right
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            rig.velocity = new Vector3(moveSpeed, rig.velocity.y, 0f);
            SetDirection(0);
        }
        //Handles moving left
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            rig.velocity = new Vector3(-moveSpeed, rig.velocity.y, 0f);
            SetDirection(2);
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
            SetDirection(3);
        }
        //Handles moving down
        else if (Input.GetAxisRaw("Vertical") < 0f)
        {
            rig.velocity = new Vector3(rig.velocity.x, -moveSpeed, 0f);
            SetDirection(1);
        }
        else
        {
            rig.velocity = new Vector3(rig.velocity.x, 0f, 0f);
        }
    }

    //Direction uses an int value to determine which direction the player is facing
    // 0:   Right
    // 1:   Down
    // 2:   Left
    // 3:   Up
    private void SetDirection(byte direction)
    {
        this.direction = direction;
    }
}