using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioClip labMusic, levelMusic, bossMusic, victoryMusic;
    [SerializeField] string musicType;
    [SerializeField] GameObject box1, box2;

    private AudioSource audioManager, nowPlaying;

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
            audioManager.clip = levelMusic;
            audioManager.PlayDelayed(1f);
        }   
    }
}
