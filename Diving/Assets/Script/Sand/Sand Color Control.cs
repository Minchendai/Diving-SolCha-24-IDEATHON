using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandColorControl : MonoBehaviour
{
    public Material[] materials= new Material[4];
    public int speed = 200;
    private int changeColor = -1;
    private GameObject floor;
    public GameObject normalFloor;
    private int index;
    private int timer;

    // Start is called before the first frame update
    void Start()
    {
        floor = GameObject.FindWithTag("Sand");
        index = 0;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find("Stop")) {
            if (GameObject.FindWithTag("Shovel")) {
                // Color gets lighter when shoveling
                changeColor = -1;
            } else if (GameObject.FindWithTag("Vacuum")||GameObject.FindWithTag("Sponge")||GameObject.FindWithTag("Biodegrader")) {
                changeColor = 0;
            }
            timer++;
            if (timer>speed) {
                timer = 0;
                index+=changeColor;
                if (index<0) {
                    index = 0;
                } else if (index > 3) {
                    index = 3;
                }
                floor.GetComponent<Renderer>().material = materials[index];
            }
            if (index==0) {
                normalFloor.SetActive(true);
            } else {
                normalFloor.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Color gets darker by oil pollution
        changeColor = 1;
    }
}
