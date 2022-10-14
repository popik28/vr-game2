using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : AttackingAI
{
    private bool isChasing;
    [SerializeField] GameObject wallA, wallB;

    // Start is called before the first frame update
    void Start()
    {
        
        isChasing = false;
        base.Start();
        anim.Play("Jump");

    }

    // Update is called once per frame
    void Update()
    {
        if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
            base.Update();

        if (health > 100 && !wallA.GetComponent<MoveWall>().closed) 
        {
            wallA.GetComponent<MoveWall>().closeSpikes();
            wallB.GetComponent<MoveWall>().closeSpikes();
        }

        else if (health > 100 && wallA.GetComponent<MoveWall>().closed) 
        {
            wallA.GetComponent<MoveWall>().openSpikes();
            wallB.GetComponent<MoveWall>().openSpikes();
        }
            
    }

}
