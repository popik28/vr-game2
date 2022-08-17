using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField] float objDamage = 20;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {   /// <summary>Use Damage() function from PlayerHealth script when player gets hit with a sword</summary>
            other.GetComponent<PlayerHealth>().Damage(objDamage);
        }
    }
}
