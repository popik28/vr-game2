using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalTeleporter : MonoBehaviour
{   /// <summary>Universal script used to teleport player to certain objects</summary>
    public GameObject teleportTo;
    private Transform newPosition;
    // Start is called before the first frame update
    void Start()
    {
        newPosition = teleportTo.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {   /// <summary>Teleport player to new position</summary>
            other.transform.position = newPosition.position;
            other.transform.rotation = newPosition.rotation;
        }
    }
}
