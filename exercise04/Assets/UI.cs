using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{

    public AirplaneController ac; //ui must see the player controller to display the score
    public TextMeshProUGUI scoreDisplay, winDisplay;
    public TextMeshProUGUI timerDisplay;
    //[SerializeField] Text timerDisplay;

    private float timer = 0f; 
    public float timerDuration = 120f; //setting the time

    void Start()
    {
        timer = timerDuration;
        //scoreDisplay.text = "";
        //timerDisplay = "";
        //winDisplay.text = "";
    }

    void Update()
    {
        timer -= 1 * Time.deltaTime;
        timerDisplay.text = timer.ToString ("0");

        if (timer <= 0)
        {
            timer = 0;
            winDisplay.text = "Time's Up! Game Over";
        }

        if (GameObject.FindGameObjectsWithTag("coin").Length <= 0)
        {
            winDisplay.text = "You found all the coins! You win!";
        }

        scoreDisplay.text = "Score: " + ac.score;
    }
}
