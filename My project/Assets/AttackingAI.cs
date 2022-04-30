using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackingAI : MonoBehaviour
{
    private Transform playerPos;
    [SerializeField] private float moveSpeed, spotRange, attackRange;
    private float distance;
    public bool isChasing, isAttacking, walkingBack;
    public Vector3 originalPos;
    Animator anim;
    public NavMeshAgent agent;

    /*
    public float MoveSpeed(float speed)
    {
        get
        {
            return moveSpeed;
        }
        set 
        {
            moveSpeed = speed;
        }
    }
    */

    // Start is called before the first frame update
    public void Start()
    {
        originalPos = this.transform.position;
        anim = GetComponent<Animator>();
        isAttacking = false;
        this.agent.speed = moveSpeed;
    }

    // Update is called once per frame
    public void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Player") != null)
            playerPos = GameObject.FindGameObjectWithTag("Player").transform;

        distance = Vector3.Distance(playerPos.position, transform.position);

        if (distance <= attackRange)
        {
            AnimateEnemy("Attack", 0);
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
          
            AnimateEnemy("Walk", moveSpeed);
        }

        if (walkingBack && Vector3.Distance(this.transform.position, originalPos) <= 1)
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
}
