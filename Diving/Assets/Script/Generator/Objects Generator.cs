using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilMotionController : MonoBehaviour
{
    public GameObject prefab;
    public int objectNum = 4;
    public float radius = 2f;

    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<objectNum; i++) {
            float angle = i * Mathf.PI * 2 / objectNum;
            Vector3 pos = transform.position;
            pos.x += i*radius;
            float angleDegrees = -angle*Mathf.Rad2Deg;
            Vector3 rot = transform.eulerAngles;
            rot += new Vector3(0, angleDegrees, 0);
            Instantiate(prefab, pos, Quaternion.Euler(rot));
        }
    }

    public void Generate()
    {
        for (int i=0; i<objectNum; i++) {
            float angle = i * Mathf.PI * 2 / objectNum;
            Vector3 pos = transform.position;
            pos.x += i*radius;
            float angleDegrees = -angle*Mathf.Rad2Deg;
            Vector3 rot = transform.eulerAngles;
            rot += new Vector3(0, angleDegrees, 0);
            Instantiate(prefab, pos, Quaternion.Euler(rot));
        }
    }
}
