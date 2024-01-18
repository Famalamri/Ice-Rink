using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    private void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        //handles rotation
        yRotation += mouseX;

        xRotation -= mouseY;

        //limit looking up/down to 90 degrees
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotate cam
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);

        //rotate player along y axis
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
