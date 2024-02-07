using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{
    float weaponTimerValue = 0f;
    public float weaponTimerTarget = 10f;
    public float speed = 10f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(speed * Time.deltaTime, 0);
        rb.MovePosition(rb.position + direction);

        weaponTimerValue += 1f * Time.deltaTime;
        if (weaponTimerValue > weaponTimerTarget)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SendMessageUpwards("TakeDamage", 3, SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }
}
