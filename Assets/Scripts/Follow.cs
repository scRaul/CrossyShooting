using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    Transform target;

    float smoothSpeed = 10f;
    public Vector3 offset = new Vector3(1, 30, -1);
    private void Awake()
    {
        target = GameObject.Find("PlayerChicken").GetComponent<Transform>();
    }
    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
  
    }
}
/*
 refrenced from https://youtu.be/MFQhpwc6cKE
 Class Follow
    Data Members:
        Transfrom Target;

    Functions:
        LateUpdate(); // move towards target



*/