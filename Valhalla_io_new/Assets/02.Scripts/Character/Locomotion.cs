using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotion : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private float moveSpeed = 5.0f;

    private Camera mainCamera;
    private Animator animator;
    #endregion Variables

    #region Unity Methods
    private void Awake()
    {
        animator = GetComponent<Animator>();

        mainCamera = Camera.main;
    }

    private void Update()
    {
        Movement();
    }
    #endregion Unity Methods

    #region Main Methods
    private void Movement()
    {
        Vector3 moveVec = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        bool isMove = moveVec.magnitude != 0;
        if(isMove)
        {
            Vector3 lookForward = mainCamera.transform.forward;
            lookForward.y = 0;
            Vector3 lookRight = mainCamera.transform.right;
            lookRight.y = 0;

            Vector3 dir = (lookForward * moveVec.z + lookRight * moveVec.x).normalized;

            transform.forward = dir;
            transform.position += dir * moveSpeed * Time.deltaTime;
        }

        animator.SetBool("Move", isMove);
    }
    #endregion Main Methods
}
