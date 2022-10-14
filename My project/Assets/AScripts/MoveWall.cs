using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    [SerializeField] bool wallA;
    public bool closed = false;
    private Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.localPosition;

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void closeSpikes() 
    {
        if (wallA && transform.localPosition.z > originalPosition.z - 13)
        {
            transform.localPosition += Vector3.back * 2 * Time.deltaTime;
        }

        else if (!wallA && transform.localPosition.z < originalPosition.z + 14)
        {
            transform.localPosition += Vector3.forward * 2 * Time.deltaTime;
        }

        else closed = true;
    }

    public void openSpikes() 
    {
        if (wallA && transform.localPosition.z < originalPosition.z)
        {
            transform.localPosition += Vector3.forward * 2 * Time.deltaTime;
        }

        else if (!wallA && transform.localPosition.z > originalPosition.z)
        {
            transform.localPosition += Vector3.back * 2 * Time.deltaTime;
        }

        else closed = false;
    }
}
