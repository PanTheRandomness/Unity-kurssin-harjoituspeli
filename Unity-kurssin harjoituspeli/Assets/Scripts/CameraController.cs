using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject playerShip;

    private float height = 4.0f;
    private float distance = 5.0f;
    private float followDamping = 8f;
    private float rotationDamping = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(playerShip.name);
        transform.position = playerShip.transform.TransformPoint(0f, height, -distance);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, playerShip.transform.TransformPoint(0f, height, -distance), Time.deltaTime * followDamping);
        Quaternion rotation = Quaternion.LookRotation(playerShip.transform.position - transform.position + Vector3.up * 3);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation,Time.deltaTime * rotationDamping);
    }
}
