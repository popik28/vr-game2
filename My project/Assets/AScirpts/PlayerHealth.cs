using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private float health, maxHealth = 100;
    [SerializeField] GameObject videoPlayer, playerCamera;
    [SerializeField] int timeToStop;
    [SerializeField] GameObject m_GotHitScreen;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        videoPlayer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //healthText.text = "Health" + health + "%";
        
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        if (health <= 0) 
        {
          //  videoPlayer.SetActive(true);
           // playerCamera.SetActive(false);   
            //Destroy(videoPlayer, timeToStop);
        }
     /*   if(health < maxHealth)
        {
            var color = m_GotHitScreen.GetComponent<Image>().color;
            color.a = 0.5f;
            m_GotHitScreen.GetComponent<Image>().color = color;
        }*/
        
        HealthBarFiller();
    }

    public void HealthBarFiller()
    {
        slider.value = health / maxHealth;
        var color = m_GotHitScreen.GetComponent<Image>().color;
        float red = (maxHealth -health)/100;
        color.a = red;
        m_GotHitScreen.GetComponent<Image>().color = color;
        //a
    }

    public void Damage(float damage)
    {
        if (health > 0)
        {
            health -= damage;
        }  
    }

    public void Heal(float healingPoints)
    {
        if (health < maxHealth)
        {
            health += healingPoints;
        }
    }

    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.transform.tag == "enemyWeapon")
    //    {
    //        Damage(swordHit);
    //    }
    //}
}
