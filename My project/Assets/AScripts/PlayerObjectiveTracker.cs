using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectiveTracker : MonoBehaviour
{
    //Script exists to track ongoing player objectives, completion and new item/area unlocks.
    public bool hasClimbingGear; //Required to climb the castle wall.
    // Start is called before the first frame update
    public GameObject ClimbCollider;
    public GameObject NpcHandJet;
    public GameObject NpcClimb;
    public GameObject NpcStart;

    void Start()
    {
        hasClimbingGear = false;
        NpcHandJet.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (hasClimbingGear)
        {
            Destroy(ClimbCollider);
            NpcClimb.SetActive(true); /// <summary>Activate 2nd NPC on objective collection.</summary>
            NpcStart.SetActive(false);

        } /// <summary>Track main objective to remove collider for the climbing wall</summary>

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "NPC_3_Activation") 
        {
            hasClimbingGear = false;
            NpcHandJet.SetActive(true);
            NpcClimb.SetActive(false);
        }
    } /// <summary>Activate 3rd NPC after collecting hand jets.</summary>


}
