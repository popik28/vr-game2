using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWhenColide : MonoBehaviour
{
    public bool move;
    Vector3 originalPos;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
        move = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!move && transform.position.y > originalPos.y)
        {
           // if (transform.position.y > originalPos.y)
                transform.position -= Vector3.up * 2 * Time.deltaTime;
        }

        if (move && transform.position.y < originalPos.y + 3)
        {
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
