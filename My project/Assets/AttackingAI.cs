using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackingAI : MonoBehaviour
{
    private Transform playerPos;
    public float moveSpeed, spotRange, attackRange;
    private float distance;
    public bool isChasing, isAttacking, walkingBack;
    public Vector3 originalPos;
    Animator anim;
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = this.transform.position;
        anim = GetComponent<Animator>();
        isAttacking = false;
        this.agent.speed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Player") != null)
            playerPos = GameObject.FindGameObjectWithTag("Player").transform;

        distance = Vector3.Distance(playerPos.position, transform.position);

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

        if (distance > spotRange && Vector3.Distance(this.transform.position, originalPos) > 1)
        {
            walkingBack = true;
            agent.SetDestination(originalPos);
            anim.Play("Walk");
            agent.speed = moveSpeed;

        }

        if (walkingBack && Vector3.Distance(this.transform.position, originalPos) <= 1)
        {
            anim.Play("Idle");
            walkingBack = false;
        }
    }
}
