using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolOBJ : MonoBehaviour
{
    int Patrol = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * Patrol * Time.deltaTime * 30;
       

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "wall")
        {

            Patrol *= -1;
          transform.Rotate(0, 180, 0);
        
        }

    }
}
