using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public bool tripleSpread;
    public bool tripleStraight;
    public bool increaseSpread;
    public bool healthPack;
    public float packValue;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void addHealth()
    {
        
    }

    public Health playerHealth;

    //methods to add to player
    public void OntriggerEnter2D(Collider2D collision)
    {
        PowerUps powerUps = collision.GetComponent<PowerUps>();
        if(powerUps.healthPack == true)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                playerHealth.health += ;

                //add tag player to player object
            }
        }
       
    }



    //methods to add to ...


}
