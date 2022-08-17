using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;

    // Update is called once per frame
    void Update()
    {   /// <summary>Calculates player distance from portal</summary>
        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;

        if (transform.name == "Camera_B")
        {
            playerOffsetFromPortal += new Vector3(-3, 2, -2.5f);
        }

        if (transform.name == "Camera_A")
        {
            playerOffsetFromPortal += new Vector3(4.5f, -1.5f, 2.6f);
        }
        transform.position = portal.position + playerOffsetFromPortal;

        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);
        /// <summary>Calculate angle from portal to accurately teleport facing the right way</summary>

        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
        Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }
}
