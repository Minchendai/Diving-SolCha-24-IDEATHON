using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilMotionController : MonoBehaviour
{
    public GameObject oilPrefab;
    public int objectNum = 4;
    public float radius = 2f;

    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<objectNum; i++) {
            float angle = i * Mathf.PI * 2 / objectNum;
            Vector3 pos = transform.position;
            float angleDegrees = -angle*Mathf.Rad2Deg;
            Quaternion rot = Quaternion.Euler(0, angleDegrees, 0);
            Instantiate(oilPrefab, pos, rot);
        }
    }
}
