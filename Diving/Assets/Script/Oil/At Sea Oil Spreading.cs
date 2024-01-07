using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtSeaOilSpreading : MonoBehaviour
{
    public GameObject canvas;
    public float spreadSpeed = 0.0001f;
    public float vacuumSpeed = 0.001f;
    private bool canSpread = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpread && !canvas.activeSelf)
        {
            Vector3 scaleChange = new Vector3(spreadSpeed, spreadSpeed, 0);
            transform.localScale += scaleChange;
        }
        if (transform.localScale.x <= 700) transform.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider collider)
    {
        switch (collider.gameObject.layer)
        {
            case 9: 
                canSpread = false;
                break;
            case 11:
                canSpread = false;
                print("11");
                Vector3 scaleChange = new Vector3(vacuumSpeed, vacuumSpeed, 0);
                transform.localScale -= scaleChange;
                break;
        }
        print("Collide");
    }

    private void OnTriggerStay(Collider collider)
    {
        switch (collider.gameObject.layer)
        {
            case 11:
                canSpread = false;
                print("11");
                Vector3 scaleChange = new Vector3(vacuumSpeed, vacuumSpeed, 0);
                transform.localScale -= scaleChange;
                break;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        switch (collider.gameObject.layer)
        {
            case 11:
                canSpread = true;
                break;
        }
    }
}
