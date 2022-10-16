using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    [SerializeField] float objDamage;
    private bool hasAttacked;
    private void Start()
    {
        hasAttacked = false;
    }
    private void Update()
    {
        if(hasAttacked)
        Invoke(nameof(SwitchAttack), 5);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemies" && !hasAttacked)
        {   /// <summary>Use Damage() function from EnemyHealth script when enemy gets hit with a sword</summary>
            other.GetComponent<EnemyHealth>().Damage(objDamage);
            hasAttacked = true;
        }
    }
    void SwitchAttack()
    {
        Debug.Log("asd");
        hasAttacked = false;
    }
    IEnumerator Delay()
    {
        /// <summary>
        ///  De;ay
        /// </summary>
        yield return new WaitForSeconds(2);
    }
}