using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class approaching : MonoBehaviour
{
    bool move = false;
    int c = 2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > c)
        {
            move = false;
            c = c * 2;
        }
        if (move)
            transform.position += Vector3.right * Time.deltaTime * 3;
            
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
            move = true;
    }
}