using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public GameObject player;
    PlayerHealth playerHealth;
    public int GoldValue;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        GoldValue = 5;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Player")) //Kills enemy if shot by Player
        {
            playerHealth.SetGoldText(GoldValue);
            Destroy(this.gameObject);
        }
    }
}
