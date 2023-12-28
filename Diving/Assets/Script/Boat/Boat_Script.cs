using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat_Script : MonoBehaviour
{
    public CharacterController player;
    public Rigidbody body;
    public GameObject barrier_prefab;
    public float speed = 2f;
    public Vector3 roatation_speed = new Vector3(0, 100, 0);
    public Material line_material;
    private bool canPlaceBarrier = true;
    private float distance;
    private LineRenderer line;
    

    private void Start()
    {
        player = GetComponent<CharacterController>();
        body = GetComponent<Rigidbody>();
        line = gameObject.AddComponent<LineRenderer>();
        // 设置材料的属性
        line.material = line_material;
        line.positionCount = 0; //　设置该线段由几个点组成

        // 设置线段起点宽度和终点宽度
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
    }
    private void Update()
    {
        float move = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        Quaternion deltaRotation = Quaternion.Euler(Input.GetAxis("Horizontal") * move  * roatation_speed * Time.fixedDeltaTime);
        float x = move * System.MathF.Sin((body.rotation.eulerAngles.y - 90) * System.MathF.PI / 180);
        float y = move * System.MathF.Cos((body.rotation.eulerAngles.y - 90) * System.MathF.PI / 180);
        body.MoveRotation(body.rotation * deltaRotation);
        player.Move(new Vector3(x, 0, y));
        distance -= Mathf.Sqrt(x * x + y * y);
        if (distance <= 0)
        {
            canPlaceBarrier = true;
        }
        if (canPlaceBarrier)
        {
            GameObject.Instantiate(barrier_prefab, transform.position + new Vector3(0, 1, 0), body.transform.rotation * Quaternion.Euler(new Vector3(0, 90, 0)));
            distance = 30;
            canPlaceBarrier = false;
            line.positionCount += 1;
            line.SetPosition(line.positionCount - 1, transform.position + new Vector3(0, 3.3F, 0));
        }
    }

}


