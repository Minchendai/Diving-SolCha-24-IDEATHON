using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandColorControl : MonoBehaviour
{
    public Material[] materials= new Material[4];
    public int speed = 200;
    private bool isShovelling;
    private GameObject floor;
    private int index;
    private int timer;
    // Start is called before the first frame update
    void Start()
    {
        isShovelling = false;
        floor = GameObject.FindWithTag("Sand");
        index = 0;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        if (timer>speed) {
            timer = 0;
            if (!isShovelling) {
                index++;
            } else {
                index--;
            }
            if (index<0) {
                index = 0;
            } else if (index > 3) {
                index = 3;
            }
            floor.GetComponent<Renderer>().material = materials[index];
        }
    }
}
