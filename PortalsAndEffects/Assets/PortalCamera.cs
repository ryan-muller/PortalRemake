using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
	public Transform playerCamera;
	public Transform portal;
	public Transform otherPortal;

	// Update is called once per frame
	void LateUpdate()
	{
		Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
		playerOffsetFromPortal = Vector3.Scale(playerOffsetFromPortal, new Vector3(-1, 1, -1));
		transform.position = portal.position + playerOffsetFromPortal ;

        //var relativePosition = transform.InverseTransformPoint(playerCamera.position);
        //relativePosition = Vector3.Scale(relativePosition, new Vector3(-1, 1, -1));
        //transform.position = otherPortal.TransformPoint(relativePosition);

        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.localRotation, otherPortal.localRotation);

        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);

        Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
        newCameraDirection = Vector3.Scale(newCameraDirection, new Vector3(-1, 1, -1));
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);

    }
}
