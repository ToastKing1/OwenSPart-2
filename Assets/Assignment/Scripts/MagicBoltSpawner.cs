using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBoltSpawner : MonoBehaviour
{

    public float timerSpeed = 1;
    float Timer;
    public GameObject Bolt;

    // Update is called once per frame
    void Update()
    {
        // timer adds up every frame
        Timer += timerSpeed * Time.deltaTime;
        // if timer reaches 10 seconds (will shorten over time) it will spawn a bolt
        if (Timer > 10)
        {
            // position randomization
            int randomized = Random.Range(0, 10);
            // if and else statement to try keeping it away from player
            if (randomized > Random.Range(0, 10))
            {
                Bolt.transform.position = new Vector2(Random.Range(-10, -5), Random.Range(-5, 5));
            }
            else
            {
                Bolt.transform.position = new Vector2(Random.Range(10, 5), Random.Range(-5, 5));
            }
            // set the speed of the bolt to the timer speed
            Bolt.GetComponent<MagicBolt>().speed = timerSpeed;
            // set if its going to heal or damage
            if (randomized > 6)
            {
                Bolt.GetComponent<MagicBolt>().damage = -20;
            }
            else
            {
                Bolt.GetComponent<MagicBolt>().damage = 20;
            }
            // adding a point to the player
            Bolt.GetComponent<MagicBolt>().movePoints = new List<Vector2>();
            Bolt.GetComponent<MagicBolt>().currentPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Bolt.GetComponent<MagicBolt>().movePoints.Add(Vector2.zero);
            // instance the bolt
            Instantiate(Bolt);
            // reset timer
            Timer = 0;
            // add more timer speed and clamp it
            timerSpeed = Mathf.Clamp(timerSpeed+0.5f, 0, 5);
        }
    }
}
