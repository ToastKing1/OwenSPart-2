using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerScript : MonoBehaviour
{
    float health = 100;
    bool isDead = false;
    float deathTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if the player is dead, only this section of the code runs
        if (isDead)
        {
            deathTimer += 1 * Time.deltaTime;
            // switch to lose scene after the death timer is done
            if (deathTimer < 100)
            {

            }
        }
        // code runs normal if the player isn't dead
        else
        {
            // if the player is redirecting magic bolts
            if (Input.GetMouseButtonDown(0))
            {

            }
        }
        
    }

    void Damaged(float damage)
    {
        if (!isDead)
        {
            health -= damage;
            if (health < 0)
            {
                isDead = true;
            }
        }
    }
}
