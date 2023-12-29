using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilSpreading : MonoBehaviour
{
    public bool isShrinking = false;
    public float spreadSpeed = 0.0001f;
    public float shrinkSpeed = 0.0005f;
    public float largestScale = 2f;
    public float smallestScale = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isShrinking && transform.localScale.x<largestScale) {
            // Oil spreading
            Vector3 scaleChange = new Vector3(spreadSpeed, spreadSpeed, spreadSpeed);
            transform.localScale += scaleChange;
        } else if (isShrinking) {
            if (transform.localScale.x>smallestScale) {
                // Oil shrinking
                Vector3 scaleChange = new Vector3(shrinkSpeed, shrinkSpeed, shrinkSpeed);
                transform.localScale -= scaleChange;
            } else {
                // Oil invisible
                gameObject.SetActive(false);
            }
        } else {
            // Size unchange
        }
    }
}
