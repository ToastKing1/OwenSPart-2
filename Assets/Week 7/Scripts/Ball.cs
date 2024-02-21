using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector2 kickOffPosition = new Vector2(0,0);
    public Rigidbody2D rb;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Goal")
        {
            Controller.score += 1;
            rb.velocity = Vector2.zero;
            rb.transform.position = kickOffPosition;
        }
    }
}
