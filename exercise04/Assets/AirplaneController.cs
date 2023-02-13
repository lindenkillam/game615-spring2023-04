using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    GameObject airplane;

    // Start is called before the first frame update
    void Start()
    {
        airplane = GameObject.Find("Airplane");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            airplane.transform.Rotate(0, 0, 0.01f);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            airplane.transform.Rotate(0, 0, -0.01f);
        }

        if(Input.GetKey(KeyCode.UpArrow))
        {
            airplane.transform.Rotate(0.003f, 0, 0);
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            airplane.transform.Rotate(-0.003f, 0, 0);
        }
    }
}
