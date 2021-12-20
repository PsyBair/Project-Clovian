using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float speed;
    public Animator animator; // Public reference to the Player animator component
    public GameObject fireballPrefab; // Public reference to the fireball prefab
    public GameObject lightningPrefab;
    public GameObject icewallPrefab;
    public GameObject icestarPrefab;
    public float fbfireRate; // How long until another fireball can be shot
    public float lbfireRate; // How long until another lightning bolt can be shot
    public float iwfireRate; // How long until an ice wall "melts"
    public float isfireRate; // How long until more ice stars can be shot
    private float fbnextFire; // Some sort of counter thing that makes it work idk
    private float lbnextFire; // Some sort of counter thing that makes it work idk
    private float iwnextFire; // Some sort of counter thing that makes it work idk
    private float isnextFire; // Some sort of counter thing that makes it work idk
    public float fireDespawn; // How long a fireball lasts on screen
    public float lightningDespawn;
    public float icewallDespawn;
    public float icestarDespawn; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal")); // This sets the condition "Horizontal" in the player animator
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));

        if(Input.GetKey(KeyCode.J) && Time.time > fbnextFire) // Fireball
        {
            fbnextFire = Time.time + fbfireRate;
            GameObject fireball = Instantiate(fireballPrefab, new Vector2(transform.position.x + 0.5f, transform.position.y), Quaternion.identity); // Spawns a fireball
            fireball.GetComponent<Rigidbody2D>().velocity = new Vector2(11.0f, 0.0f);
            GameObject.Destroy(fireball, fireDespawn);
        }
        if (Input.GetKey(KeyCode.I) && Time.time > lbnextFire) // Lightning
        {
            lbnextFire = Time.time + lbfireRate;
            GameObject lightningbolt1 = Instantiate(lightningPrefab, transform.position, Quaternion.identity);
            GameObject lightningbolt2 = Instantiate(lightningPrefab, transform.position, Quaternion.identity);
            GameObject lightningbolt3 = Instantiate(lightningPrefab, transform.position, Quaternion.identity);
            lightningbolt1.GetComponent<Rigidbody2D>().velocity = new Vector2(17.0f, 0.0f);
            lightningbolt2.GetComponent<Rigidbody2D>().velocity = new Vector2(17.0f, 8.0f);
            lightningbolt3.GetComponent<Rigidbody2D>().velocity = new Vector2(17.0f, -8.0f);
            GameObject.Destroy(lightningbolt1, lightningDespawn);
            GameObject.Destroy(lightningbolt2, lightningDespawn);
            GameObject.Destroy(lightningbolt3, lightningDespawn);
        }
        if (Input.GetKey(KeyCode.L) && (Time.time > iwnextFire || Time.time > isnextFire)) // Ice
        {
            if (Time.time > iwnextFire)
            {
                iwnextFire = Time.time + iwfireRate;
                GameObject icewall = Instantiate(icewallPrefab, new Vector2(transform.position.x + 2.0f, transform.position.y), Quaternion.identity);
                GameObject.Destroy(icewall, icewallDespawn);
            }
            if (Time.time > isnextFire)
            {
                isnextFire = Time.time + isfireRate;
                GameObject icestar1 = Instantiate(icestarPrefab, new Vector2(transform.position.x - 0.5f, transform.position.y), Quaternion.identity);
                GameObject icestar2 = Instantiate(icestarPrefab, new Vector2(transform.position.x - 0.5f, transform.position.y), Quaternion.identity);
                GameObject icestar3 = Instantiate(icestarPrefab, new Vector2(transform.position.x - 0.5f, transform.position.y), Quaternion.identity);
                GameObject icestar4 = Instantiate(icestarPrefab, new Vector2(transform.position.x - 0.5f, transform.position.y), Quaternion.identity);
                icestar1.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 5.0f);
                icestar2.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, -5.0f);
                icestar3.GetComponent<Rigidbody2D>().velocity = new Vector2(-2.0f, 5.0f);
                icestar4.GetComponent<Rigidbody2D>().velocity = new Vector2(-2.0f, -5.0f);
                GameObject.Destroy(icestar1, icestarDespawn);
                GameObject.Destroy(icestar2, icestarDespawn);
                GameObject.Destroy(icestar3, icestarDespawn);
                GameObject.Destroy(icestar4, icestarDespawn);
            }   
        }
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f); // This sets the actual player movement
        transform.position = transform.position + movement * speed * Time.deltaTime; // And this carries it out
    }
}
