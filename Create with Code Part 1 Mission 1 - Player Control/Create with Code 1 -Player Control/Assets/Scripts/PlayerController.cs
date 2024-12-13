using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //Private Variables
    [SerializeField] float horsePower = 20.0f;
    [SerializeField] float turnSpeed = 25.0f;
    [SerializeField] private GameObject centerOfMass;
    [SerializeField] private TextMeshProUGUI speedometerText;
    [SerializeField] private TextMeshProUGUI rpmText;
    [SerializeField] private float speed;
    [SerializeField] private float rpm;
    
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;
    private float horizontalInput;
    private float verticalInput;

    private Rigidbody playerRb;
    
    
    

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = transform.InverseTransformPoint(centerOfMass.transform.position);
    }

    // Update is called once per frame
    private void Update()
    {
        //speed = Mathf.Round(playerRb.velocity.magnitude * 2.237f);
        //speedometerText.SetText("Speed: " + speed + "mph");

        
    }

    void FixedUpdate()
    {

        if (IsOnGround())
        {
            //This is where we get player input
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            //We move the vehicle forward
            // transform.Translate(Vector3.forward*Time.deltaTime*speed*forwardInput);
            playerRb.AddRelativeForce(Vector3.forward * verticalInput * horsePower);
            //print speed
            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 2.237f);
            speedometerText.SetText("Speed: " + speed + " mph");
            //We turn the vehicle
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
          

            //print RPM
            rpm = Mathf.Round((speed % 30) * 40);
            rpmText.SetText("RPM: " + rpm);
        }
      
    }
    
    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
       /* if (wheelsOnGround == 4)
        {
            return true;
        } 
        else
        {
            return false;
        }*/
       
       return wheelsOnGround >= 2;
    }
}
