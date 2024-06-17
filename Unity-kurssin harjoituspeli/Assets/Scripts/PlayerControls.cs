using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float thrustSpeed;
    public float turnSpeed;
    public float hoverPower;
    public float hoverHeight;
    public float boostPower;

    private float thrustInput;
    private float turnInput;
    private Rigidbody shipRigidBody;
    private bool boostInput;

    // Start is called before the first frame update
    void Start()
    {
        shipRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        thrustInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
        //Debug.LogFormat("Thrust Input: {0}", thrustInput);
        //Debug.LogFormat("Turn Input: {0}", turnInput);
        boostInput = Input.GetButton("Fire3");
    }

    void FixedUpdate()
    {
        float boost = boostInput ? boostPower: 1;
        // Turning the ship
        shipRigidBody.AddRelativeTorque(0f, turnInput * turnSpeed * boost, 0f);

        // Moving the ship
        shipRigidBody.AddRelativeForce(0f, 0f, thrustInput * thrustSpeed * boost);

        // Hovering
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, hoverHeight))
        {
            float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
            Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverPower;

            shipRigidBody.AddForce(appliedHoverForce, ForceMode.Acceleration);
            /* if (hit.distance < hoverHeight / 2)
            {
                appliedHoverForce *= 2;
            }*/
        }
    }
}
