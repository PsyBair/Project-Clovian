﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed; //Enemy movement speed
    public GameObject enemyshotPrefab;
    public float enemyfireRate; //How often enemies can fire
    private float nextFire;
    public float shotDespawn; //How long an enemy shot lasts for
    private Rigidbody2D rb; //Enemy rigidbody
    private Vector2 screenBounds;

    public GameObject player;
    PlayerHealth playerHealth;
    public int XPValue;

    public GameObject goldPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        player = GameObject.FindWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        XPValue = 2;
    }

    // Update is called once per frame
    void Update()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)); //Defines screen boundaries for the purpose of despawning objects outside of view
        if (GetComponent<Renderer>().isVisible)
        {
            rb.velocity = new Vector2(-speed, 0.0f); //Sets enemy movement direction and speed
        }

        if (GetComponent<Renderer>().isVisible)
        {
            if (GameObject.FindWithTag("Player"))
            {
                if (Time.time > nextFire)
                {
                    nextFire = Time.time + enemyfireRate;
                    GameObject enemyshot = Instantiate(enemyshotPrefab, transform.position, Quaternion.identity);
                    GameObject.Destroy(enemyshot, shotDespawn);
                }
            }
        }

        if (transform.position.x < -screenBounds.x) //Despawns enemy once outside of screen boundaries
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D (Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Shot")) //Kills enemy if shot by Player
        {
            playerHealth.SetXPText(XPValue);
            GameObject gold = Instantiate(goldPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        if (coll.gameObject.tag.Equals("Enemy")) //Kills enemy if they run into another enemy
        {
            Destroy(this.gameObject);
        }
    }
}