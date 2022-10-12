using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : AttackingAI
{
    bool jump;
    // Start is called before the first frame update
    void Start()
    {
            base.Start();
            anim.Play("Jump");
            
    }

    // Update is called once per frame
    void Update()
    {
        if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
            base.Update();
        
    }
}
