using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject successScreen;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Normal Floor")&&!GameObject.FindWithTag("Oil")){
            successScreen.SetActive(true);
        }
    }
}
