using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //MOUSELOOK SCRIPT FOR RBMOVEMENT.CS

   
   [SerializeField] private float sensX; // X look sensitivity
   [SerializeField] private float sensY; // Y look sensitivity
   [SerializeField] Transform cam; // Camera
    [SerializeField] Transform Orientation;
   

    // OTHER VARIABLES
    float mouseX;
    float mouseY;
    float multiplier = 0.01f;
    float xRotation;
    float yRotation;


    private void Start() // Executes everything in this function in the start
    {      
        Cursor.lockState = CursorLockMode.Locked; // Locks the cursor to the middle of the screen
        Cursor.visible = false; // Makes the cursor not visible
    }

    private void Update() // Executes everything in this function every frame
    {
        MyInput(); // Executes MyInput function

        cam.transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
        Orientation.transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    void MyInput()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");

        yRotation += mouseX * sensX * multiplier;
        xRotation -= mouseY * sensY * multiplier;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    }

    
}
