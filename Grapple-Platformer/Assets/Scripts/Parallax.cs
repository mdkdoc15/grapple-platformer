using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    [SerializeField] private float parallaxFactor = 0;
    public GameObject cam;
 
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    void FixedUpdate()
    {
        float temp     = cam.transform.position.x * (1 - parallaxFactor);
        float distance = cam.transform.position.x * parallaxFactor;
 
        Vector3 newPosition = new Vector3(startpos + distance, transform.position.y, transform.position.z);
 
        transform.position = newPosition;
 
        if (temp > startpos + (length))    startpos += 2 * length;
        else if (temp < startpos - (length)) startpos -= 2* length;
    }
}
