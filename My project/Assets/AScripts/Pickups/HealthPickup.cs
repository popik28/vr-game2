using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    /// <summary>Handles player healing, manages sound and item rotation</summary>
    public bool rotate;
    public float rotationSpeed, healingValue;
    public AudioClip collectSound;

    // Update is called once per frame
    void Update()
    {
        if (rotate) /// <summary>If item rotation is enabled, rotate item</summary>
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {/// <summary>Finds player health script and update his health points to new value</summary>
            other.GetComponent<PlayerHealth>().Heal(healingValue);
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
            Destroy(gameObject);
        }
    }
}
