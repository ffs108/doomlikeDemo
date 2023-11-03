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
using UnityEngine.UI;

public class DamageVisual : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Color img = GetComponent<Image>().color;
        img.b = Mathf.Lerp(img.b, 0, Time.deltaTime);
        img.g = Mathf.Lerp(img.g, 0, Time.deltaTime);
        GetComponent<Image>().color = img;
    }

    //private void ChangeColour()
}
