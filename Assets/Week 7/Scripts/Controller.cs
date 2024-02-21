using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class Controller : MonoBehaviour
{
    public Slider chargeSlider;
    float charge;
    public float maxCharge = 5;
    Vector2 direction;
    public static float score = 0;
    public TextMeshProUGUI scoreText;
    public static Player selectedPlayer { get; private set; }
    public static void SetSelectedPlayer(Player player)
    {
        if (selectedPlayer != null)
        {
            selectedPlayer.Selected(false);
        }
        player.Selected(true);
        selectedPlayer = player;
    }

    private void FixedUpdate()
    {
        if (direction != Vector2.zero)
        {
            selectedPlayer.Move(direction);
            direction = Vector2.zero;
            charge = 0;
            chargeSlider.value = charge;
        }
    }

    private void Update()
    {
        scoreText.text = "Score: "+score.ToString();
        if (selectedPlayer == null) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            charge = 0;
            direction = Vector2.zero;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            charge = Mathf.Clamp(charge + 5 * Time.deltaTime, 0, maxCharge);
            chargeSlider.value = charge;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - selectedPlayer.transform.position).normalized * charge;
        }
    }

}
