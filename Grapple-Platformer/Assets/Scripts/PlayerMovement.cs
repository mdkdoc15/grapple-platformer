using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController2D mController;
    [SerializeField] private float mMoveSpeed = 40f;
    
    private float mHorizontalMove = 0f;
    private bool mJump = false;
    private bool mCrouch = false;
    
    private void Update()
    {
        mHorizontalMove = Input.GetAxisRaw("Horizontal") * mMoveSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            mJump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            mCrouch = true;
        }

        if (Input.GetButtonUp("Crouch"))
        {
            mCrouch = false;
        }
    }

    private void FixedUpdate()
    {
        mController.Move(mHorizontalMove * Time.fixedDeltaTime, mCrouch, mJump);
        mJump = false;
    }
}
