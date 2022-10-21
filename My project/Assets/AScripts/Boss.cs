using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : AttackingAI
{
    private bool isChasing;
    private float ogSpotRange, ogAttackRange;
    [SerializeField] GameObject wallA, wallB;
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        animator.SetBool("Pose", true);
        ogSpotRange = getSpotRange();
        ogAttackRange = getAttackRange();
        isChasing = false;
        base.Start();

    }

    // Update is called once per frame
    void Update()
    {
        base.Update();

        if (health <= 400 && !wallA.GetComponent<MoveWall>().closed)
        {
            wallA.GetComponent<MoveWall>().closeSpikes();
            wallB.GetComponent<MoveWall>().closeSpikes();
            spotRange = 0;//check when phase 2 and in combat mode ( dont stop attacking )
        }

        if (health >= 250 && wallA.GetComponent<MoveWall>().closed)
        {
            wallA.GetComponent<MoveWall>().openSpikes();
            wallB.GetComponent<MoveWall>().openSpikes();
        }
     checkPhase();
        
        if (health <= 0)
        {
            for (int i = 1; i < 5; i++)
            {
                GameObject.Find("SM_Prop_Brazier_" + i.ToString()).GetComponent<FireBall>().enabled = false;
            }

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("Pose", true);
    }

    void checkPhase()
    {//Used to check amount of boss health in order to transition between phases via animation parameters.
        if(health > 400)
        {
            animator.SetInteger("phase", 1);
        }

        if(health >= 200 && health <= 350)
        {
            animator.SetInteger("phase", 2);
            attackRange = -1;
            spotRange = -1;
        }
        else if(health<250)
        {
            spotRange = 6;
            attackRange = ogAttackRange;
            wallA.GetComponent<MoveWall>().closed = true;
            wallA.GetComponent<MoveWall>().openSpikes();
            wallB.GetComponent<MoveWall>().openSpikes();
            animator.SetInteger("phase", 3);

            for (int i = 1; i < 5; i++)
            {
                GameObject.Find("SM_Prop_Brazier_" + i.ToString()).GetComponent<FireBall>().enabled = true ;
            }

            
        }
    }
}
