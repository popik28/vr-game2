using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : AttackingAI
{
    private bool isChasing;
    private float ogSpotRange;
    [SerializeField] GameObject wallA, wallB;
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        animator.SetBool("Pose", true);
        ogSpotRange = getSpotRange();
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


    }
    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("Pose", true);
    }
    void checkPhase()
    {//Used to check amount of boss health in order to transition between phases via animation parameters.
        if(health > 400)
        {
                    animator.SetInteger("phase",1);
        }

        if(health >= 250 && health <= 400)
        {
                      animator.SetInteger("phase",2);
            attackRange = -1;
        }
        else
        {
            wallA.GetComponent<MoveWall>().closed = true;

                      wallA.GetComponent<MoveWall>().openSpikes();
                     wallB.GetComponent<MoveWall>().openSpikes();
                    
                    animator.SetInteger("phase",3);
            
        }
    }
}
