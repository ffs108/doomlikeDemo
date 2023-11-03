/*
 *
 * ISTA 351 Intro to Game Dev
 * University of Arizona
 * HUD demo sample code file
 *
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float playerSpeed = 8f; //sped up from 5 -- more than the 25% req. but noticable better to move around
    private CharacterController controller;
    private Vector3 input;
    private Vector3 move;
    private float gravity = -10f;
    public float momentumDamp = 3f;

    public Animator anime;
    private Boolean isWalking;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        MovePlayer();

        anime.SetBool("isWalking", isWalking);
    }

    void GetInput()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            input = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            input.Normalize();
            input = transform.TransformDirection(input);
            isWalking = true;
        }
        else
        {
            input = Vector3.Lerp(input, Vector3.zero, Time.deltaTime * momentumDamp);
            isWalking = false;
        }
        

        move = (input * playerSpeed) + (Vector3.up * gravity);
    }

    void MovePlayer()
    {
        controller.Move(move * Time.deltaTime);
    }

}
