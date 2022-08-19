using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHitEnemy : MonoBehaviour
{
    public float arrowDamage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemies"))
            other.GetComponent<EnemyHealth>().Damage(arrowDamage);
    }
}
