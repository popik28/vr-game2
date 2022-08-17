using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {   /// <summary>Handle dummy animation when touched by player or sword</summary>
        if (other.transform.tag == "Player" || other.transform.tag == "Katana")
        {
            anim.Play("pushed");
        }
    }

    private void OnTriggerExit(Collider other)
    {

    }
}
