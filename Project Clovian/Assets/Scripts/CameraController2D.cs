using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController2D : MonoBehaviour
{
    public float step;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
    }

    void Update()
    {
        var cameraPosition = Camera.main.gameObject.transform.position;
        cameraPosition.x += step * Time.deltaTime; // Scrolls camera smoothly!
        Camera.main.gameObject.transform.position = cameraPosition;
    }
}
