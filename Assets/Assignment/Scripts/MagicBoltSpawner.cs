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
        Timer += timerSpeed * Time.deltaTime;
        if (Timer > 10)
        {
            int randomized = Random.Range(0, 10);
            if (randomized > Random.Range(0, 10))
            {
                Bolt.transform.position = new Vector2(Random.Range(-10, -5), Random.Range(-5, 5));
            }
            else
            {
                Bolt.transform.position = new Vector2(Random.Range(10, 5), Random.Range(-5, 5));
            }

            Bolt.GetComponent<MagicBolt>().speed = timerSpeed;
            if (randomized > 6)
            {
                Bolt.GetComponent<MagicBolt>().damage = -20;
            }
            else
            {
                Bolt.GetComponent<MagicBolt>().damage = 20;
            }
            Bolt.GetComponent<MagicBolt>().movePoints = new List<Vector2>();
            Bolt.GetComponent<MagicBolt>().currentPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Bolt.GetComponent<MagicBolt>().movePoints.Add(Vector2.zero);
            Instantiate(Bolt);
            Timer = 0;
            timerSpeed = Mathf.Clamp(timerSpeed+1, 0, 5);
        }
    }
}
