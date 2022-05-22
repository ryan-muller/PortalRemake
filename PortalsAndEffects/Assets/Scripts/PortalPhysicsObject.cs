using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalPhysicsObject : PortalTraveller
{
    public float force = 10f;
    private Rigidbody _rb;
    public Color[] colors;
    static int i;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        graphicsObject.GetComponent<MeshRenderer>().material.color = colors[i];
        i++;
        if (i > colors.Length - 1)
        {
            i = 0;
        }
    }

    public override void Teleport(Transform fromPortal, Transform toPortal, Vector3 pos, Quaternion rot)
    {
        base.Teleport(fromPortal, toPortal, pos, rot);
        _rb.velocity = toPortal.TransformVector(fromPortal.InverseTransformVector(_rb.velocity));
        _rb.angularVelocity = toPortal.TransformVector(fromPortal.InverseTransformVector(_rb.angularVelocity));
    }
}
