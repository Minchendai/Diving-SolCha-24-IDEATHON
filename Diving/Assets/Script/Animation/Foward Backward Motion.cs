using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FowardBackwardMotion : MonoBehaviour
{
    private float pivot;
    private int left = -1;
    public bool random = true;
    public float magnitude = 5;
    public float speed = 0.08f;
    // Start is called before the first frame update
    void Start()
    {
        if (random) {
            magnitude = Random.Range(3, 5);
            speed = Random.Range(0.10f,0.18f);
            if (magnitude>4) {
                left = 1;
            }
        }
        pivot = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < pivot-magnitude || transform.position.x > pivot+magnitude) {
            // Change direction
            left *= -1;
        }
        transform.position += new Vector3(left*speed,0,0);
        
    }
}
