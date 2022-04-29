using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackingAI : MonoBehaviour
{
    private Transform playerPos;
    [SerializeField] private float moveSpeed, spotRange, attackRange;
    [SerializeField] private float distance;
    [SerializeField] private bool isChasing, isAttacking, walkingBack;
    [SerializeField] private Vector3 originalPos;
    [SerializeField] private Animator anim;
    [SerializeField] private NavMeshAgent agent;

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
