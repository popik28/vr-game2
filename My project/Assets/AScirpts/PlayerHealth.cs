using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private float health, maxHealth = 100;


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;   
    }

    // Update is called once per frame
    void Update()
    {
        //healthText.text = "Health" + health + "%";
        
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        HealthBarFiller();
    }

    public void HealthBarFiller()
    {
        slider.value = health / maxHealth;
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
