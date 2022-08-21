using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectiveTracker : MonoBehaviour
{
    //Script exists to track ongoing player objectives, completion and new item/area unlocks.
    public bool hasClimbingGear; //Required to climb the castle wall.
    // Start is called before the first frame update
    public GameObject box;
    public GameObject NpcClimb;
    public GameObject NpcStart;

    void Start()
    {
        hasClimbingGear = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasClimbingGear)
        {
            Destroy(box);
            NpcClimb.SetActive(true);
            NpcStart.SetActive(false);

        }

    }
}
