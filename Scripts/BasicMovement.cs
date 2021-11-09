using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float speed;
    public Animator animator;
    public GameObject arrowPrefab;
    public float fireRate;
    private float nextFire;
    public float fireDespawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));

        if(Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject fireball = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
            fireball.GetComponent<Rigidbody2D>().velocity = new Vector2(11.0f, 0.0f);
            GameObject.Destroy(fireball, fireDespawn);
        }
        
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
        transform.position = transform.position + movement * speed * Time.deltaTime;
    }
}
