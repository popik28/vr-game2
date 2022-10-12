using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : AttackingAI
{
    [SerializeField] GameObject wallA;
    [SerializeField] GameObject wallB;
    private bool isChasing;
    private Vector3 originalPositionA, originalPositionB;

    // Start is called before the first frame update
    void Start()
    {
        originalPositionA = wallA.transform.position;
        originalPositionB = wallB.transform.position;

        isChasing = false;
        base.Start();
        anim.Play("Jump");

    }

    // Update is called once per frame
    void Update()
    {
        if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
            base.Update();

        closeSpikes();
    }

    void closeSpikes() 
    {
        if (wallA.transform.position.z > originalPositionA.z - 8)
        {
            wallA.transform.position -= Vector3.back * 2 * Time.deltaTime;
        }
    }
}
