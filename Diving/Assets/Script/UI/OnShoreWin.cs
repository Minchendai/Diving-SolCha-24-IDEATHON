using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject successScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Normal Floor")&&!GameObject.FindWithTag("Oil")){
            successScreen.SetActive(true);
        }
    }
}
