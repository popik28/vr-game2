using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTutorialSound : MonoBehaviour
{
    public AudioClip collectSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
            Destroy(gameObject);
        } /// <summary>Play audio when collecting items.</summary>
    }

}
