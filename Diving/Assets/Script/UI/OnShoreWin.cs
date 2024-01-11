using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject successScreen;
    public GameObject dialogContainer;
    public GameObject next;
    public GameObject restart;
    private int level=1;
    private int timer=0;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("OilGenerator")) {
            timer++;
        }
        if (!GameObject.FindWithTag("Oil")&&timer>=200&&!GameObject.Find("Success Screen")) {
            timer=0;
            if (level==1) {
                successScreen.SetActive(true);
                level++;
            } else if (GameObject.Find("Normal Floor")) {
                successScreen.SetActive(true);
                if (level>=4) {
                    next.SetActive(false);
                    restart.SetActive(true);
                }
                level++;
            }
        }
    }
}
