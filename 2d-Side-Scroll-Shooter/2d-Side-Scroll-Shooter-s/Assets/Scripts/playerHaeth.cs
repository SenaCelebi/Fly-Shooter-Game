using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHaeth : MonoBehaviour
{
    public float fullHealth;
    public GameObject deathFX;
   

    float currentHealth;

    playerController controlMovement;

    //HUD Variables
    public Slider healthSlider;

    int counter = 0;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = fullHealth;
        controlMovement = GetComponent<playerController>();

        healthSlider.maxValue = fullHealth;
        healthSlider.value = fullHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addDamage(float damage)
    {
        if (damage <= 0) return;
            currentHealth -= damage;
            healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            makeDead();
            SceneManager.LoadScene("Game Over");

        }
    }

    public void addHealth(float healtAmount)
    {
        counter++;
        currentHealth += healtAmount;
        if (currentHealth > fullHealth) currentHealth = fullHealth;
        healthSlider.value = currentHealth;
        
    }

    public void makeDead()
    {

        Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
