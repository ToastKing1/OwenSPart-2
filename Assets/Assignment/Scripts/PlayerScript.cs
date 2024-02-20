using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerScript : MonoBehaviour
{
    public float health = 100;
    bool isDead = false;
    public float deathTimer;
    public Animator animator;
    public GameObject levelManager;
    public Slider slider;

    private void Start()
    {
        // player has max health at start
        health = 100;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        // if the player is dead, only this section of the code runs
        if (isDead)
        {
            deathTimer += 1 * Time.deltaTime;
            // switch to lose scene after the death timer is done
            if (deathTimer > 2)
            {
                // sends a message to the scene manager
                levelManager.SendMessageUpwards("SceneChange");
            }
        }
        // code runs normal if the player isn't dead
        else
        {
            // if the player is redirecting magic bolts they play an animation
            if (Input.GetMouseButton(0))
            {
                animator.SetBool("Redirecting", true);
            }
            // otherwise they are idle
            else
            {
                animator.SetBool("Redirecting", false);
            }
        }
        
    }

    // this runs when the player collides with a bolt
    public void Damaged(float damage)
    {
        // if the player isn't dead
        if (!isDead)
        {
            // health is minused by damage
            // healing works as "health -= -20" for example, which makes it positive
            health -= damage;
            // clamp the health
            health = Mathf.Clamp(health, 0, 100);
            // this is to check if the player has run out of health, otherwise the player plays the hurt animation
            if (health <= 0)
            {
                isDead = true;
                animator.SetTrigger("Death");
            }
            else
            {
                animator.SetTrigger("Hurt");
            }
            // update the slider
            slider.value = health;
        }
    }
}
