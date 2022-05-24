using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWhenColide : MonoBehaviour
{
    public bool move = false;
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
            transform.position = originalPos;
        }

        if (move)
        {
            Vector3 gateUp = new Vector3(transform.position.x, 2, transform.position.z);
            transform.position = gateUp;
            //transform.position =  gateUp * Time.deltaTime * 0.1f;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
            move = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            move = false;
        }
    }
}
