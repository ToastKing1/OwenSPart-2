using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class Plane : MonoBehaviour
{
    public List<Vector2> points;
    public float newPointThreshold = 0.2f;
    Vector2 lastPosition;
    LineRenderer lineRenderer;
    Vector2 currentPosition;
    Rigidbody2D rigid;
    public float speed = 1.0f;
    public AnimationCurve landing;
    float landingTimer;
    SpriteRenderer spriteRender;
    public bool land = false;

    void OnMouseDown()
    {
        points = new List<Vector2>();
        Vector2 currentPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        points.Add(currentPosition);
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    void OnMouseDrag()
    {
        Vector2 currentPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Vector2.Distance(currentPosition, lastPosition) > newPointThreshold)
        {
            points.Add(currentPosition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, currentPosition);
            lastPosition = currentPosition;
        }

    }

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
        rigid = GetComponent<Rigidbody2D>();
        speed = Random.Range(1f, 3f);
        spriteRender = GetComponent<SpriteRenderer>();
        
    }

    void FixedUpdate()
    {
        currentPosition = new Vector2(transform.position.x, transform.position.y);
        if (points.Count > 0)
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rigid.rotation = -angle;
        }
        rigid.MovePosition(rigid.position + (Vector2)transform.up * speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        
        if(land == true)
        {
            landingTimer += 0.1f * Time.deltaTime;
            float interpolation = landing.Evaluate(landingTimer);
            if (transform.localScale.z < 0.1f)
            {
                Destroy(gameObject);
            }
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, interpolation);
        }

        if (points.Count > 0)
        {
            if(Vector2.Distance(currentPosition, points[0]) < newPointThreshold)
            {
                points.RemoveAt(0);

                for (int i = 0; i < lineRenderer.positionCount - 2; i++)
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));
                }
                lineRenderer.positionCount--;
            }
        }

    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
            spriteRender.color = Color.red;
        
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRender.color = Color.white;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<Plane>()){
            if (Vector3.Distance(currentPosition, collision.transform.position) < 1)
            {
                Destroy(gameObject);
            }
        }
        

    }
}
