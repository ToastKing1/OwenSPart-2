using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using Unity.VisualScripting;

public class GoalkeeperController : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 direction;
    public Transform goalControllerTransform;
    float distance;
    float goalLine = 2.5f;
    float speed = 3;

    private void FixedUpdate()
    {
        if (Controller.selectedPlayer != null) {
            direction = (goalControllerTransform.position - Controller.selectedPlayer.transform.position);

            distance = direction.magnitude;

            if (distance > goalLine)
            {
                direction = (Vector2)goalControllerTransform.position - direction.normalized * goalLine;
            }
            else
            {
                direction = (Vector2)goalControllerTransform.position - direction / 2;
            }


            rb.transform.position = Vector3.MoveTowards(rb.transform.position, direction, speed * Time.deltaTime);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
