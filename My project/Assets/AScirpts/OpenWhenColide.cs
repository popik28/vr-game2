using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWhenColide : MonoBehaviour
{
    bool move = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 2)
            move = false;
        if (move)
            transform.position += Vector3.up * Time.deltaTime * 3;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
            move = true;
    }
}
