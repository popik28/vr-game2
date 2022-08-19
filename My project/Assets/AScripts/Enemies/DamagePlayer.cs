using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField] float objDamage = 20;
    
    // Update is called once per frame
    void Update()
    {
        if (GetComponentInParent<EnemyHealth>().health <= 0)
            GetComponent<BoxCollider>().enabled = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {   /// <summary>Use Damage() function from PlayerHealth script when player gets hit with a sword</summary>
            other.GetComponent<PlayerHealth>().Damage(objDamage);
        }
    }
}
