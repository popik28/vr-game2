using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] GameObject[] otherSoundPlayers;
    
    private AudioSource audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (GameObject soundPlayer in otherSoundPlayers)
            {
                soundPlayer.GetComponent<AudioSource>().Stop();
            }

            audioManager.PlayDelayed(2.5f);
        }   
    }
}
