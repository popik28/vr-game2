using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    public Transform player;
    public Transform reciever;
    private bool playerIsOverlapping = false;

    // Update is called once per frame
    void Update()
    {
        //if (playerIsOverlapping)
        //{
        //    Vector3 portalToPlayer = player.position - transform.position;
        //    float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

        //    if (dotProduct < 0f)
        //    {
        //        float rotationDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
        //        rotationDiff +=180;
        //        player.Rotate(Vector3.up, rotationDiff);

        //        Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
        //        player.position += reciever.position + positionOffset;
        //        Debug.Log("Teleport" + player.position);


        //        playerIsOverlapping = false;
        //    }
        //}
    }

     private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && reciever.name == "ColiderPlane_B")
        {
            Debug.Log("wee");
            playerIsOverlapping = true;

            other.transform.position = reciever.position - new Vector3(1, 0, 0);
        }



        if (other.tag == "Player" && reciever.name == "ColiderPlane")
        {
            Debug.Log("wee");
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
