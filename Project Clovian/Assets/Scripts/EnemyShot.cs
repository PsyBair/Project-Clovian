using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject target; // Have to make a public reference to the GameObject With Tag "Player" in order to make the aimed shots work
    public float shotSpeed; // The moving speed of the enemy shots
    Vector2 shotDirection; // Holds the normalized shot vector once computed

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player");
        shotDirection = (target.transform.position - transform.position).normalized * shotSpeed; // Makes enemies aim their shots towards the players current location
        rb.velocity = new Vector2(shotDirection.x, shotDirection.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
