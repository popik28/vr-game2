using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWhenColide : MonoBehaviour
{
    public bool move = true;
    Vector3 originalPos;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        if (!move)
        {
            if (transform.position.y > 0.15)
                transform.position -= Vector3.up * 2 * Time.deltaTime;
        }

        if (move)
        {
            //Vector3 gateUp = new Vector3(transform.position.x, 2, transform.position.z);
            //transform.position = gateUp;
            if (transform.position.y < 2)
                transform.position += Vector3.up * 2 * Time.deltaTime;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            move = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            move = false;
        }
    }
}
