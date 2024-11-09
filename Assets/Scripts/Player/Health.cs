using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBar;


    // Start is called before the first frame update
    void Start()
    {
        //health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0,1);

        if(health <= 0)
        {
            Destroy(gameObject); //have transition to game over screen life is on 0
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Asteroids"))
        {
            health -= 25;
            Destroy(other.gameObject);
            //add tag player to player object
        }
        if (other.gameObject.CompareTag("HealthPack"))
        {
            health += 25;
            Destroy(other.gameObject);
        }

    }
}
