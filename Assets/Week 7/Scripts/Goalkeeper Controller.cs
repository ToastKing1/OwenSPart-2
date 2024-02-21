using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;

public class GoalkeeperController : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 direction;
    public Transform goalControllerTransform;

    private void FixedUpdate()
    {
        //direction = (goalControllerTransform.position - Controller.selectedPlayer.transform.position).normalized;
        direction = (goalControllerTransform.position - Controller.selectedPlayer.transform.position).normalized;
        rb.transform.position = (Vector2)goalControllerTransform.position - direction;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
