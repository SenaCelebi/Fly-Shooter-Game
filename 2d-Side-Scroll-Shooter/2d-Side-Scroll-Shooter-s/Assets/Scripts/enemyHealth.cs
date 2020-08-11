using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float enemyMaxHealt;
    float currentHealth;

    public GameObject enemyDeathFX;

    public bool drops;
    public GameObject theDrop;
 



    void Start()
    {
        currentHealth = enemyMaxHealt;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            makeDead();
          
        }
    }

    void makeDead()
    {
        UiManager.instance.killCount++;
        UiManager.instance.UpdateKillCounterUI();
        Destroy(gameObject);
        Instantiate(enemyDeathFX, transform.position, transform.rotation);
        if (drops) Instantiate(theDrop, transform.position, transform.rotation);
    }
}
