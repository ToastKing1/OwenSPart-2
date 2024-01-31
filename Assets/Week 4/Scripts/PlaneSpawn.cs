using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Timers;
using UnityEngine;
using UnityEngine.U2D;

public class PlaneSpawn : MonoBehaviour
{

    public GameObject Plane;
    public float timerValue = 0f;
    public float timerTarget = 5f;
    public Sprite[] spriteArray;

    void Update()
    {
        timerValue += 1f * Time.deltaTime;
        if (timerValue > timerTarget)
        {
            timerValue = 0f;
            timerTarget = Random.Range(1, 5);

            // spawn the plane
            Vector3 position = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);

            Plane.GetComponent<SpriteRenderer>().sprite = spriteArray[Random.Range(0,3)];

            Instantiate(Plane, position, transform.rotation = Quaternion.Euler(0, 0, Random.Range(-180, 180)));
        }
    }
}
