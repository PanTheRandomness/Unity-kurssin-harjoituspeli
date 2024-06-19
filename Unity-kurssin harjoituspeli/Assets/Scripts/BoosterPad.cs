using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterPad : MonoBehaviour
{
    public GameObject player;

    [SerializeField]
    private float turboAmount;
    [SerializeField]
    private float turboDuration;
    private float lastTurboAt;

    void Start()
    {
        lastTurboAt = -turboDuration;
    }

    
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (Time.time - lastTurboAt < turboDuration)
        {
            player.GetComponent<Rigidbody>().AddForce(transform.forward * turboAmount);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Entered Trigger");
        if (Time.time - lastTurboAt >= turboDuration)
        {
            if (other.tag == "Player")
            {
                //Debug.Log("Player confirmed");
                //isBoosting = true;
                lastTurboAt = Time.time;
            }
        }
    }
}
