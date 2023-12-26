using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat_Script : MonoBehaviour
{
    public CharacterController player;
    public Rigidbody body;
    public float speed = 2f;
    public Vector3 roatation_speed = new Vector3(0, 100, 0);

    private void Start()
    {
        player = GetComponent<CharacterController>();
        body = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        float move = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        Quaternion deltaRotation = Quaternion.Euler(Input.GetAxis("Horizontal") * move  * roatation_speed * Time.fixedDeltaTime);
        float x = move * System.MathF.Sin((body.rotation.eulerAngles.y - 90) * System.MathF.PI / 180);
        float y = move * System.MathF.Cos((body.rotation.eulerAngles.y - 90) * System.MathF.PI / 180);
        body.MoveRotation(body.rotation * deltaRotation);
        player.Move(new Vector3(x, 0, y));
    }

}


