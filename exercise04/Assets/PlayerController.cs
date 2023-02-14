using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject airplane;
    Rigidbody rb;
    float rotateSpeed, rotateRate, pitchRate, forwardSpeed;
    public bool lose;
    public float score; //score is held for the UI to display

    // Start is called before the first frame update
    void Start()
    {
        airplane = GameObject.Find("Airplane");
        rotateSpeed = 0f;
        rotateRate = 0.01f;
        pitchRate = 0.01f;
        forwardSpeed = 1f;
        lose = false;
        score = 0;
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

    private void OnTriggerEnter(Collider other)
    {
        // 'other' is the name of the collider that just collided with the object
        // that this script ("PlayerController") is attached to. So the if statment
        // below checks to see that that object has the tag "coin". Remember that
        // the tags for GameObjects are assigned in the top left area of the
        // inspector when you select the obect.
        if (other.CompareTag("coin"))
        {
            Destroy(other.gameObject);
            score += 1;
        }
        else if (other.CompareTag("danger"))
        {
            //Destroy(other.gameObject);
            score -= 1;
            airplane.GetComponent<Rigidbody>().AddForce(transform.up * 500);
            airplane.GetComponent<Rigidbody>().AddTorque(transform.forward * 500);
            lose = true;
        }
    }
}
