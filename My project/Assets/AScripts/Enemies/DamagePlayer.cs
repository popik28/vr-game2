using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField] float objDamage = 20;
    private float ogDamage;


    // Update is called once per frame
    void Update()
    {

        if (transform.tag == "enemyWeapon" && GetComponentInParent<EnemyHealth>().health <= 0) 
        {
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void Start()
    {
        ogDamage = objDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {   /// <summary>Use Damage() function from PlayerHealth script when player gets hit with a sword</summary>
            other.GetComponent<PlayerHealth>().Damage(objDamage);
        }

        if (other.CompareTag("Shield"))
        {
            objDamage = 0;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        objDamage = ogDamage;
    }
}
