using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStopsShots : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Player")) // Kills player if they touch an enemy
        {
            Destroy(this.gameObject);
        }
    }
}
