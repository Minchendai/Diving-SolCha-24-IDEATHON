using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilColorChange : MonoBehaviour
{
    public Material[] materials = new Material[4];
    private bool isFading;
    public int speed = 200;
    public GameObject oil;
    private int index;
    private int timer;

    // Start is called before the first frame update
    void Start()
    {
        isFading = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Biodegrader")) {
            isFading = true;
        }
        if (isFading&&index<3) {
            timer++;
            if (timer>speed) {
                timer = 0;
                index++;
                if (index > 3) {
                    index = 3;
                }
                oil.GetComponent<Renderer>().material = materials[index];
            }
        }
    }
}
