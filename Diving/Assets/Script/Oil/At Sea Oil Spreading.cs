using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtSeaOilSpreading : MonoBehaviour
{
    
    public float spreadSpeed = 0.0001f;
    private bool canSpread = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpread)
        {
            Vector3 scaleChange = new Vector3(spreadSpeed, spreadSpeed, 0);
            transform.localScale += scaleChange;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == 9)
        {
            canSpread = false;
        }
    }
}
