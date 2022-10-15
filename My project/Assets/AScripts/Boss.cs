using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : AttackingAI
{
    private bool isChasing;
    private float ogSpotRange;
    [SerializeField] GameObject wallA, wallB;

    // Start is called before the first frame update
    void Start()
    {
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
            spotRange = 0;
        }

        else if (health >= 300 && wallA.GetComponent<MoveWall>().closed)
        {
            wallA.GetComponent<MoveWall>().openSpikes();
            wallB.GetComponent<MoveWall>().openSpikes();
        }
        checkPhase();


    }
    void checkPhase()
    {//Used to check amount of boss health in order to transition between phases via animation parameters.
        if(health > 400)
        {
            anim.parameters.SetValue(0,1);
        }

        if(health > 250 && health <= 400)
        {
            anim.parameters.SetValue(0,2);
        } else
        {
           anim.parameters.SetValue(0, 3);
        }
    }
}
