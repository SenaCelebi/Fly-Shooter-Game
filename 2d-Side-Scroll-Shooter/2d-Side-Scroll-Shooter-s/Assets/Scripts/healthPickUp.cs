using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthPickUp : MonoBehaviour
{

    public float healthAmount;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter2D(Collider2D other)
    {
     if (other.tag == "Player")
        {
            playerHaeth theHealth = other.gameObject.GetComponent<playerHaeth>();
            theHealth.addHealth(healthAmount);
            Destroy(gameObject);

            



        }
    }
}
