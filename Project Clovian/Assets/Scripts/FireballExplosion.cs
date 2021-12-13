using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballExplosion : MonoBehaviour
{
    public GameObject emberPrefab;
    public float emberDespawn;

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
        if (coll.gameObject.tag.Equals("Enemy")) // Kills player if they touch an enemy
        {
            GameObject ember2 = Instantiate(emberPrefab, transform.position, Quaternion.identity);
            GameObject ember3 = Instantiate(emberPrefab, transform.position, Quaternion.identity);
            GameObject ember5 = Instantiate(emberPrefab, transform.position, Quaternion.identity);
            GameObject ember6 = Instantiate(emberPrefab, transform.position, Quaternion.identity);
            ember2.GetComponent<Rigidbody2D>().velocity = new Vector2(11.0f, 11.0f);
            ember3.GetComponent<Rigidbody2D>().velocity = new Vector2(11.0f, -11.0f);
            ember5.GetComponent<Rigidbody2D>().velocity = new Vector2(-11.0f, -11.0f);
            ember6.GetComponent<Rigidbody2D>().velocity = new Vector2(-11.0f, 11.0f);
            GameObject.Destroy(ember2, emberDespawn);
            GameObject.Destroy(ember3, emberDespawn);
            GameObject.Destroy(ember5, emberDespawn);
            GameObject.Destroy(ember6, emberDespawn);
        }
    }
}
