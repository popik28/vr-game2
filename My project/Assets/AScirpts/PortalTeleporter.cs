using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    public Transform player;
    public Transform reciever;
    private bool playerIsOverlapping = false;

     private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && reciever.name == "ColiderPlane_B")
        {
            playerIsOverlapping = true;

            other.transform.position = reciever.position - new Vector3(1, 0, 0);
        }



        if (other.tag == "Player" && reciever.name == "ColiderPlane")
        {
            playerIsOverlapping = true;
            reciever.position += new Vector3(1, 0, 0);

            other.transform.position = reciever.position + new Vector3(1, 0, 0);
        }
    }

     private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = false;
        }
    }
}
