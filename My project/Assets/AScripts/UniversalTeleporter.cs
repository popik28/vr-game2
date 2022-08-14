using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalTeleporter : MonoBehaviour
{
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
        {
            other.transform.position = newPosition.position;
            other.transform.rotation = newPosition.rotation;
        }
    }
}
