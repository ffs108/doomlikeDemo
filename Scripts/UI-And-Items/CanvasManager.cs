/*
 *
 * ISTA 351 Intro to Game Dev
 * University of Arizona
 * HUD demo sample code file
 *
 */

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public TextMeshProUGUI health;
    public TextMeshProUGUI armour;
    public TextMeshProUGUI ammo;

    public Image doomGuyStatus;
    public Sprite healthyDoom;
    public Sprite hurtDoom;
    public Sprite injuredDoom;
    public Sprite criticalDoom;

    public Image healthBar;
    //private float healthDrainDamp = 0.25f;
    public Gradient healthBarGradient;


    private static CanvasManager _instance;
    public static CanvasManager Instance 
    { 
        get 
        {
            return _instance;
        } 
    }

    private void Awake()
    {
        if(_instance != null && _instance != this) Destroy(this.gameObject);
        else _instance = this;
    }

    public void UpdateHealth(int healthVal, int maxHealth)
    {
        health.text = healthVal.ToString() + "%";
        UpdateFaceIndicator(healthVal);
        UpdateHealthBar(healthVal, maxHealth);
    }

    public void UpdateArmour(int armourVal)
    {
        armour.text = armourVal.ToString() + "%";
    }

    public void UpdateAmmo(int ammoVal)
    {
        ammo.text = ammoVal.ToString();
    }

    public void UpdateFaceIndicator(int healthVal)
    {
        if (healthVal >= 75) doomGuyStatus.sprite = healthyDoom; //healthy
        else if (healthVal < 75 && healthVal >= 50) doomGuyStatus.sprite = hurtDoom;
        else if (healthVal < 50 && healthVal >= 25) doomGuyStatus.sprite = injuredDoom;
        else doomGuyStatus.sprite = criticalDoom; //gonna die
    }

    public void UpdateHealthBar(int healthVal, int maxHealth)
    {
        float target = (float) healthVal / maxHealth; //keep the float cast here; otherwise the int division will go through and make your float 0.0f!

        float curHealth = healthBar.fillAmount;
        //healthBar.fillAmount = Mathf.Lerp(curHealth, target, Time.deltaTime);
        //Debug.Log(target); ------------- Originally planned for this to be a slower transition from values but I could only think about doing it in a Coroutine

        healthBar.fillAmount = target;
        healthBar.color = healthBarGradient.Evaluate(target);
    }

}
