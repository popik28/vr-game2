using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private float health, maxHealth = 100;
    [SerializeField] GameObject videoPlayer, playerCamera;
    [SerializeField] int timeToStop;
    [SerializeField] GameObject m_GotHitScreen;
    [SerializeField] AudioClip hitSound;


    // Start is called before the first frame update
    void Start()
    {

        health = maxHealth;
        //videoPlayer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //healthText.text = "Health" + health + "%";
        
        if (health > maxHealth)
        {   /// <summary>Controls player health, not being able to heal more than max health</summary>
            health = maxHealth;
        }   

        if (health <= 0) 
        {   /// <summary>Handles death</summary>
            SceneManager.LoadScene(2);
        }

        HealthBarFiller();
    }

    public void HealthBarFiller()
    {   /// <summary>Handles health bar update and displays effect of taking damage</summary>
        slider.value = health / maxHealth;
        var color = m_GotHitScreen.GetComponent<Image>().color;
        float red = (maxHealth -health)/100 - 0.4f;
        color.a = red;
        m_GotHitScreen.GetComponent<Image>().color = color;
    }

    public void Damage(float damage)
    {   /// <summary>Handles taking damage</summary>
        if (health > 0)
        {
            AudioSource.PlayClipAtPoint(hitSound, transform.position);
            health -= damage;
        }  
    }

    public void setHealth(float hp)
    {   /// <summary>setHealth used to update health in tutorial</summary>
        health = hp;
    }

    public void Heal(float healingPoints)
    {
        if (health < maxHealth)
        {   /// <summary>Handles healing and minimizes red damage effect</summary>
            health += healingPoints;
            var color = m_GotHitScreen.GetComponent<Image>().color;
            float red = (health + healingPoints) / 100 - 0.4f;
            color.a = red;
            m_GotHitScreen.GetComponent<Image>().color = color;
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
