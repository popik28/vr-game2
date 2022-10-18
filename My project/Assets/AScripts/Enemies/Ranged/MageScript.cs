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
    [SerializeField] GameObject projectile, shootFromHere;
    private bool alreadyAttacked, playerInAttackRange;
    public LayerMask whatIsPlayer;

    //Animations
    private Animator anim;
    private MeshCollider meshCollider;



    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        player = GameObject.Find("PlayerController");
        anim = GetComponent<Animator>();
        meshCollider = GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();

        if (health <= 0)
        {
            anim.Play("Die");
            meshCollider.enabled = false;
            StartCoroutine(DespawnDeadEnemy());
            return;
        }

        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInAttackRange)
        {
            anim.SetBool("isAttacking", false);
        }

        if (playerInAttackRange)
        {
            Vector3 targetPosition = new Vector3(player.transform.position.x, 0, player.transform.position.z);
            transform.LookAt(targetPosition);
        }

        if (playerInAttackRange && !alreadyAttacked)
        {
            AttackPlayer();
        }
    }

    private void AttackPlayer()
    {
        anim.SetBool("isAttacking", true);

        if (!alreadyAttacked && anim.GetBool("isAttacking"))
        {
            //Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            //rb.transform.position = shootFromHere.transform.position;
            //rb.AddForce(transform.forward * 3.5f, ForceMode.Impulse);
            Attack();

            alreadyAttacked = true;

            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void Attack()
    {
        /// <summary>
        ///  Uses animation event to spawn projectile and shoot at player
        /// </summary>
        Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.transform.position = shootFromHere.transform.position;
        rb.AddForce(transform.forward * 3.5f, ForceMode.Impulse);
    }

    IEnumerator DespawnDeadEnemy()
    {
        /// <summary>
        ///  Despawns dead enemies after a certain time
        /// </summary>
        yield return new WaitForSeconds(20);
        Destroy(gameObject);
    }

    IEnumerator Delay()
    {
        /// <summary>
        ///  Delay
        /// </summary>
        yield return new WaitForSeconds(2);
    }
}
