using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol : MonoBehaviour
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

        if (transform.localPosition.z <= -60 || transform.localPosition.z >= 60)
        {
            Patrol *= -1;
            transform.Rotate(0, 180, 0);
        }
       
    }
   
}
