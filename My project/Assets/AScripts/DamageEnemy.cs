using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    [SerializeField] float objDamage;
    private bool hasAttacked;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemies" && !hasAttacked)
        {   /// <summary>Use Damage() function from EnemyHealth script when enemy gets hit with a sword</summary>
            other.GetComponent<EnemyHealth>().Damage(objDamage);
           Invoke("Test",10f);
        }
    }
    void Test(){
        Debug.Log("2");
    }
 
}