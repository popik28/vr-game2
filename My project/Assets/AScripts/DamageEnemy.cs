using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    [SerializeField] float objDamage = 50;

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
        if (other.transform.tag == "Enemies")
        {   /// <summary>Use Damage() function from EnemyHealth script when enemy gets hit with a sword</summary>
            other.GetComponent<EnemyHealth>().Damage(objDamage);
        }
    }
}