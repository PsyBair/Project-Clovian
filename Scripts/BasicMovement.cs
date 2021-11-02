using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float speed;
    public Animator animator;
    public GameObject arrowPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));

        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject fireball = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
            fireball.GetComponent<Rigidbody2D>().velocity = new Vector2(11.0f, 0.0f);
        }

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
        transform.position = transform.position + movement * speed * Time.deltaTime;
    }
}
