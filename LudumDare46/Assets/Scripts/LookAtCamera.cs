using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Transform target;
    private void Start()
    {
        target = GameObject.Find("Camera").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        transform.LookAt(target, Vector3.up);
    }
}
