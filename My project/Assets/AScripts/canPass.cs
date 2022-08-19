using BNG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canPass : MonoBehaviour
{
    public GameObject playerController;

    private Grabber [] playerGrabber;
    GameObject kid;


    // Start is called before the first frame update
    void Start()
    {
        playerGrabber = playerController.GetComponentsInChildren<Grabber>();
        kid = transform.GetChild(0).gameObject;

        
    }

    // Update is called once per frame
    void Update()
    {

        if (playerGrabber[0].ariel || playerGrabber[1].ariel)
        {   //If player is holding something in either hand, activate text + collider
            GetComponent<BoxCollider>().enabled = true;
            kid.SetActive(true) ;
        }

        if (!playerGrabber[0].ariel && !playerGrabber[1].ariel)
        {   //If player isn't holding something in either hand, deactivate text + collider
            GetComponent<BoxCollider>().enabled = false;
            kid.SetActive(false);
        }
    }
}

