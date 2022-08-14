using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTutorial : MonoBehaviour
{
    public AudioClip collectSound;


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().setHealth(40);
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
            Destroy(gameObject);
        }
    }
}
