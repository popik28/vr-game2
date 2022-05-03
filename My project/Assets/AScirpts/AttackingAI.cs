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
    private Animator anim;
    private NavMeshAgent agent;
    private bool isDying;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        boxCollider = GetComponent<BoxCollider>();
        base.Start();
        originalPos = this.transform.position;
        anim = GetComponent<Animator>();
        this.agent.speed = moveSpeed;
    }

    void Update()
    {
        base.Update();

        if (GameObject.FindGameObjectsWithTag("Player") != null)
        {
            playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        }

        distance = Vector3.Distance(playerPos.position, transform.position);

        if (health <= 0)
        {
            anim.Play("Die");
            moveSpeed = 0;
            boxCollider.enabled = false;
            StartCoroutine(DespawnDeadEnemy());
            return;
        }

        if (distance <= attackRange)
        {
            anim.Play("Attack");
            agent.speed = 0;
        }
        else if (distance <= spotRange)
        {
            agent.SetDestination(playerPos.position);
            anim.Play("Walk");
            agent.speed = moveSpeed;
        }

        if (distance > spotRange && Vector3.Distance(this.transform.position, originalPos) > 0.1)
        {
            walkingBack = true;
            agent.SetDestination(originalPos);
            anim.Play("Walk");
            agent.speed = moveSpeed;
        }

        if (walkingBack && Vector3.Distance(this.transform.position, originalPos) <= 0.1)
        {
            anim.Play("Idle");
            walkingBack = false;
        }
    }

    private void AnimateEnemy(string animation, float moveSpeed)
    {
        anim.Play(animation);
        agent.speed = moveSpeed;
    }

    IEnumerator DespawnDeadEnemy()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }

}
