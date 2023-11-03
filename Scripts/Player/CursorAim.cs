/*
 *
 * ISTA 351 Intro to Game Dev
 * University of Arizona
 * HUD demo sample code file
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorAim : MonoBehaviour
{
    public float sensitivity =  1.5f;
    public float smoothing = 1.5f;
    
    private float xPos;
    private float smoothPos;

    private float curLookPos;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        ModInput();
        MovePlayer();
    }

    void GetInput()
    {
        xPos = Input.GetAxisRaw("Mouse X");
    }

    void ModInput()
    {
        xPos *= sensitivity * smoothing;
        smoothPos = Mathf.Lerp(smoothPos, xPos, (1f / smoothing));
    }

    void MovePlayer()
    {
        curLookPos += smoothPos;
        transform.localRotation = Quaternion.AngleAxis(curLookPos, transform.up);
    }

}
