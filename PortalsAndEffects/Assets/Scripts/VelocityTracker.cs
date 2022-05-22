using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityTracker : MonoBehaviour
{

    private Vector3 prevPos;
    private Vector3 newPos;

    private Vector3 prevRot;
    private Vector3 newRot;

    public Vector3 ObjVelocity;
    public Vector3 ObjRotation;


    void Start()
    {
        prevPos = transform.position;
        prevRot = transform.eulerAngles;       
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.identity;

        newPos = transform.position;
        ObjVelocity = (newPos - prevPos) / Time.deltaTime;
        prevPos = newPos;

        newRot = transform.eulerAngles;
        ObjRotation = (newRot - prevRot) / Time.deltaTime;
        prevRot = newRot;

    }
}
