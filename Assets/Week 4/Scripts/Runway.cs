using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runway : MonoBehaviour
{
    public int score = 0;
    public Collider2D runwayCollider;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (runwayCollider.OverlapPoint(collision.transform.position))
        {
            if (collision.gameObject.GetComponent<Plane>().land == false)
            {
                score++;
                collision.gameObject.GetComponent<Plane>().land = true;
            }
        }
    }
}
