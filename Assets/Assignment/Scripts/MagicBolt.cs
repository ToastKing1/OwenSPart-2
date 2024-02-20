using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;

public class MagicBolt : MonoBehaviour
{
    public Collider2D collider;
    public float damage;
    public List<Vector2> movePoints;
    public float speed;
    public float pointThreshold = 0.4f;
    public float timer;
    public Rigidbody2D rb;
    Vector2 currentPosition;
    Vector2 lastPosition;
    public Animator animator;

    private void Start()
    {
        // set a point to the player but since the player is at (0,0), the point will be at (0,0)
        movePoints = new List<Vector2>();
        movePoints.Add(Vector2.zero);
        if (damage > 0)
        {
            animator.SetBool("Hurtful", true);
        }
        else
        {
            animator.SetBool("Hurtful", false);
        }

    }
    void OnMouseDown()
    {
        // when the mouse clicks it creates a new list and adds the mouses position first
        movePoints = new List<Vector2>();
        Vector2 currentPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        movePoints.Add(currentPosition);
    }

    void OnMouseDrag()
    {
        // when the mouse drags, each point above the point threshold in distance is added
        Vector2 currentPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Vector2.Distance(currentPosition, lastPosition) > pointThreshold)
        {
            movePoints.Add(currentPosition);
            lastPosition = currentPosition;
        }

    }

    private void FixedUpdate()
    {
        currentPosition = new Vector2(transform.position.x, transform.position.y);
        // rotate towards the point
        if (movePoints.Count > 0)
        {
            Vector2 direction = movePoints[0] - currentPosition;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rb.rotation = -angle;
        }
        // move towards the point
        rb.MovePosition(rb.position + (Vector2)transform.up * speed * Time.deltaTime);
    }

    private void Update()
    {
        
        // timer goes up every frame
        timer += 1 * Time.deltaTime;
        // when the timer hits a certain point, it will destroy the magic bolt
        if (timer > 20)
        {
            Destroy(gameObject);
        }

        // update the points list
        if (movePoints.Count > 0)
        {
            if (Vector2.Distance(currentPosition, movePoints[0]) < pointThreshold)
            {
                movePoints.RemoveAt(0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // damage the player
            collision.gameObject.SendMessageUpwards("Damaged", damage);
            // destroy the bolt
            Destroy(gameObject);
        }
    }
}
