using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackingAI : EnemyHealth
{
    private Transform playerPos;
    [SerializeField] private float moveSpeed, spotRange, attackRange;
    [SerializeField] private float distance;
    [SerializeField] private bool walkingBack;
    [SerializeField] private Vector3 originalPos;
    private BoxCollider boxCollider;
    protected Animator anim;
    private NavMeshAgent agent;
    private bool isDying;
    
    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        boxCollider = GetComponent<BoxCollider>();
        base.Start();
        originalPos = this.transform.position;
        anim = GetComponent<Animator>();
        this.agent.speed = moveSpeed;
    }

    public void Update()
    {
        base.Update();

        if (GameObject.FindGameObjectsWithTag("Player") != null)
        {
            playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        }
        /// <summary>Finds player position</summary>

        distance = Vector3.Distance(playerPos.position, transform.position);

        if (health <= 0)
        {
            anim.Play("Die");
            moveSpeed = 0;
            boxCollider.enabled = false;
            StartCoroutine(DespawnDeadEnemy());
            return;
        }
        /// <summary>Kills enemy, removes collider so player can walk over the body and uses the despawn enemy function.</summary>


        if (distance <= attackRange)
        {
            anim.Play("Attack");
            agent.speed = 0;
            Vector3 targetPosition = new Vector3(playerPos.position.x,this.transform.position.y, playerPos.position.z);
            agent.transform.LookAt(targetPosition);
        }/// <summary>Attacks player when he is in range, uses LookAt to keep facing the player</summary>
        else if (distance <= spotRange)
        {
            agent.SetDestination(playerPos.position);
            anim.Play("Walk");
            agent.speed = moveSpeed;
        }
        /// <summary>Enemy chases the player until in range of attack or out of spotting range</summary>


        if (distance > spotRange && Vector3.Distance(this.transform.position, originalPos) > 0.1)
        {
            walkingBack = true;
            agent.SetDestination(originalPos);
            anim.Play("Walk");
            agent.speed = moveSpeed;
        }
        /// <summary>When player is outside of spot range, enemy will walk back to it's original spawn location</summary>


        if (walkingBack && Vector3.Distance(this.transform.position, originalPos) <= 0.1)
        {
            anim.Play("Idle");
            walkingBack = false;
        }
        /// <summary>If enemy is in his original location and is not aggravated, play idle animation</summary>

    }

    IEnumerator DespawnDeadEnemy()
    {
        /// <summary>
        ///  Despawns dead enemies after a certain time
        /// </summary>
        yield return new WaitForSeconds(20);
        Destroy(gameObject);
    }

}
