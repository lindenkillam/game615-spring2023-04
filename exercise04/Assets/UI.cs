using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    //public Material warningText;
    public PlayerController pc; //ui must see the player controller to display the score
    public TextMeshProUGUI scoreDisplay, winDisplay;
    //public TextMeshProUGUI timerDisplay;
    [SerializeField] Text timerDisplay;

    private float timer = 0f;
    private bool holdTimer = false; 
    public float timerDuration = 120f; //setting the time

    void Start()
    {
        timer = timerDuration;
    }

    void Update()
    {
        if(!holdTimer)
        {
            timer -= Time.deltaTime;
        }
        timerDisplay.text = timer.ToString ("0");

        if (timer <= 0 && !pc.allCoinsFound)
        {
            timer = 0;
            holdTimer = true;
            pc.forwardSpeed = 0f;
            pc.rotateSpeed = 0f;
            winDisplay.text = "Time's Up! Game Over";
        }
        else if (pc.crashed)
        {
            holdTimer = true;
            winDisplay.text = "You crashed... Game Over.";
        }
        else if (pc.allCoinsFound)
        {
            holdTimer = true;
            winDisplay.text = "You found all the coins! You win!";
        }

        scoreDisplay.text = "Score: " + pc.score;
    }
}
