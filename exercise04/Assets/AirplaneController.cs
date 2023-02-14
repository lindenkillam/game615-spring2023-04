using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    GameObject airplane;
    Rigidbody rb;
    float rotateSpeed, rotateRate, pitchRate, forwardSpeed;
    //float speed;

    // Start is called before the first frame update
    void Start()
    {
        airplane = GameObject.Find("Airplane");
        rotateSpeed = 0f;
        rotateRate = 0.01f;
        pitchRate = 0.03f;
        forwardSpeed = 1f;
        //rb = airplane.GetComponent<Rigidbody>();
        //speed = 100.0f;
    }

    // Update is called once per frame
    void Update()
    {
        airplane.transform.Rotate(0, rotateSpeed * Time.deltaTime, 0, Space.Self);
        airplane.transform.Translate(transform.forward * forwardSpeed * Time.deltaTime, Space.World);
        //rb.velocity = transform.forward * speed;

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            airplane.transform.Rotate(0, 0, rotateRate);
            rotateSpeed -= rotateRate;
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            airplane.transform.Rotate(0, 0, -rotateRate);
            rotateSpeed += rotateRate;
        }

        if(Input.GetKey(KeyCode.UpArrow))
        {
            airplane.transform.Rotate(pitchRate, 0, 0);
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            airplane.transform.Rotate(-pitchRate, 0, 0);
        }
    }
}
