using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] Transform CameraPosition;
    
    void Update()
    {
        transform.position = CameraPosition.position;
    }
}
