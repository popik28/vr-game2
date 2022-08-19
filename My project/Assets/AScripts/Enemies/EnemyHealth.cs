using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public GameObject healthBarUI;
    public Slider slider;

    private float CalculateHealth()
    {
        /// <summary> Adapts amount of health to value of slider </summary>
        /// <returns>Returns a float between 0 and 1 that represents health points.</returns>
        return health / maxHealth;
    }

    // Start is called before the first frame update
    protected void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
    }

    // Update is called once per frame
    protected void Update()
    {
        slider.value = CalculateHealth();

        if (health >= 100)
        {
            healthBarUI.SetActive(false);
        }

        if(health < maxHealth)
        {
            healthBarUI.SetActive(true);
        }

        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public void Damage(float damage)
    {
        if (health > 0)
        {
            health -= damage;
        }
    }
}
