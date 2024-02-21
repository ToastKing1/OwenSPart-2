using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float charge;
    public SpriteRenderer sr;
    bool clickingOnSelf = false;
    public Color SelectedColour;
    public Color UnselectedColour;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        Selected(false);
    }

    private void OnMouseDown()
    {
        clickingOnSelf = true;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddForce(Vector2.up*5);
        }
        if (Input.GetMouseButtonDown(0) && clickingOnSelf)
        {
            Selected(true);
        }
    }

    public void Selected(bool selected)
    {
        if (selected)
        {
            sr.color = SelectedColour;
        }
        else
        {
            sr.color = UnselectedColour;
        }
    }
}
