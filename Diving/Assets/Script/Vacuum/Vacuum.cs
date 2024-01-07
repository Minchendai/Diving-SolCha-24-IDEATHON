using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacuum : MonoBehaviour
{
    public CharacterController player;
    public float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        player.Move(new Vector3(x, 0, y));
    }

    private void OnTriggerEnter(Collider collider)
    {
        switch (collider.gameObject.layer)
        {
            case 3:
                print("dead");
                break;
        }
    }
}
