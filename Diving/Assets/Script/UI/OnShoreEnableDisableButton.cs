using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableButton : MonoBehaviour
{
    public GameObject[] setActive = new GameObject[5];
    public GameObject[] disabled = new GameObject[3];

    public void OnClick() {
        for (int i=0; i<setActive.Length; i++) {
            setActive[i].SetActive(true);
        }

        for (int i=0; i<disabled.Length; i++) {
            disabled[i].SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
