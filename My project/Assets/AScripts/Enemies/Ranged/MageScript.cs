using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageScript : EnemyHealth
{
    [SerializeField] GameObject player;
    //[SerializeField] float range;
    //Attacking
    [SerializeField] float timeBetweenAttacks;
    [SerializeField] float attackRange;
    [SerializeField] GameObject projectile;
    private bool alreadyAttacked, playerInAttackRange;
    public LayerMask whatIsPlayer;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        player = GameObject.Find("PlayerController");  
    }

    // Update is called once per frame
    void Update()
    {
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (playerInAttackRange) AttackPlayer();
    }

    private bool isInRange()
    {
        return true;
    }

    private void AttackPlayer()
    {
        transform.LookAt(player.transform);
        
        if (!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 15f, ForceMode.Impulse);
            rb.AddForce(transform.up * 4f, ForceMode.Impulse);


            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }


}
