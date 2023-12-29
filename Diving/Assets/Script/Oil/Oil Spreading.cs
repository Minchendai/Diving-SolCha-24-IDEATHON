using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilSpreading : MonoBehaviour
{
    
    public float spreadSpeed = 0.0001f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x<2) {
            Vector3 scaleChange = new Vector3(spreadSpeed, spreadSpeed, spreadSpeed);
            transform.localScale += scaleChange;
        }
    }
}
