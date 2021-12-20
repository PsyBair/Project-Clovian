using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStopsShots : MonoBehaviour
{
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)); //Defines screen boundaries for the purpose of despawning objects outside of view
        if (transform.position.x < -screenBounds.x) //Despawns once outside of screen boundaries
        {
            Destroy(this.gameObject);
        }
        if (transform.position.x > screenBounds.x)
        {
            Destroy(this.gameObject);
        }
    }
}
