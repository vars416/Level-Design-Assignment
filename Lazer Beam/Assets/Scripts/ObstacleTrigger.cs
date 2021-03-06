﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleTrigger : MonoBehaviour
{
    //This script can be used to turn off any obstacles for a set time period, after which it turns them on again

    public GameObject Trigger; //The object which will be used as a trigger
    public GameObject Obstacle; //The object which will be turned off for a brief period
    private bool IsItHappening; //private bool that checks if player's collider is touching the trigger gameobject
    public float Timer; //How long will the object be turned off
    private float decreasing; //Internal float that will use the values put into "Timer"


    // Attach this script to your GameManager or any other gameobject in the scene.
    // Start is called before the first frame update
    void Start()
    {
        IsItHappening = false;
        decreasing = Timer;
    }

    // Update is called once per frame
    void Update() //Checking for Turning Off and Turning On in every frame
    {
        TurningOff();
        TurningOn();
    }

    public void OnTriggerEnter(Collider other) //Check for collisions. Feel free to remove this and call the TurningOff()
    {
        print(other);
        if (Trigger.GetComponent<Collider>() == other)
        {
            BoolCheck();
            print(IsItHappening);
        }
    }
    public void TurningOff () //Turn off the obstacle and start the timer. Can be called from another script or GameManager.
    {
        if (IsItHappening == true)
        {
            if (decreasing > 0f)
            {
                decreasing -= Time.deltaTime;
                //print(decreasing);
            }
            Obstacle.gameObject.SetActive(false);
        }
    }

    public void TurningOn () //Turn on the obstacle again once the timer is complete. Can be called from another script or GameManager.
    {
        if (decreasing <= 0f)
        {
            Obstacle.gameObject.SetActive(true);
            IsItHappening = false;
            print(IsItHappening);
            decreasing = Timer;
        }
    }

    public void BoolCheck ()
    {
        IsItHappening = true;
    }
}
