using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour

{
    [SerializeField] float steerSpeed = 1f;
    [SerializeField] float carSpeed = 20f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float forwardBackward = Input.GetAxis("Vertical") * carSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, forwardBackward, 0);

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        carSpeed = slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boostspeed")
        {
            Debug.Log("you are boosting !!!");
            carSpeed = boostSpeed;
        }
        if (other.tag == "Bumpspeed")
        {
            Debug.Log("you are Bumping");
            carSpeed = slowSpeed;

        }
        

    }
}