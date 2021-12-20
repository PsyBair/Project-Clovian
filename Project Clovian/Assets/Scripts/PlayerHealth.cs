using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;

    //PlayerMovement playerMovement;
    bool isDead;

    public TMP_Text goldText;
    public TMP_Text XPText;

    public float Gold;
    public float XP;

    void Awake()
    {
        //playerMovement = GetComponent<MyPlayerMovement>();

        currentHealth = startingHealth;
        healthSlider.value = currentHealth;

        isDead = false;

        SetGoldText(0);
        SetXPText(0);
    }

    public void SetGoldText(int GoldValue)
    {
        Gold += GoldValue;
        goldText.text = "Gold: " + Gold.ToString(); ;
    }

    public void SetXPText(int XPValue)
    {
        XP += XPValue;
        XPText.text = "XP: " + XP.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthSlider.value = currentHealth;
        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Enemy"))
        {
            TakeDamage(100);
        }
    }
}