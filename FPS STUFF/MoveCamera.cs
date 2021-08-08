using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MADE BY BLAZING LLAMA
//SIMPLE SCRIPT FOR RBMOVEMENT.CS THAT HELPS WITH CAMERA JITTERING
//NEED HELP SETTING UP? MY DISCORD: BlazingLlama#2782

public class MoveCamera : MonoBehaviour
{
    [SerializeField] Transform CameraPosition;
    
    void Update()
    {
        transform.position = CameraPosition.position;
    }
}
