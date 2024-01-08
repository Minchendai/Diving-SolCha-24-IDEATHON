using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat_Script : MonoBehaviour
{
    public GameObject canvas;
    public CharacterController player;
    public Rigidbody body;
    public GameObject barrier_prefab;
    public float speed = 2f;
    public Vector3 roatation_speed = new Vector3(0, 100, 0);
    public Material line_material;
    public GameObject StartEnd;
    public Material[] materials;
    public GameObject Step2;
    public GameObject GameOver;
    private bool canPlaceBarrier = true;
    private float distance;
    private LineRenderer line;
    private bool ends = false;
    private bool isPlaying = false;

    private void Start()
    {
        player = GetComponent<CharacterController>();
        body = GetComponent<Rigidbody>();
        line = gameObject.AddComponent<LineRenderer>();
        // 设置材料的属性
        line.material = line_material;
        line.positionCount = 1; //　设置该线段由几个点组成

        // 设置线段起点宽度和终点宽度
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
        line.SetPosition(0, transform.position);
        line.renderingLayerMask = (uint)LayerMask.NameToLayer("Barrier");
    }
    private void Update()
    {
        if (!ends && !canvas.activeSelf)
        {
            float move = Input.GetAxis("Vertical") * Time.deltaTime * speed;
            Quaternion deltaRotation = Quaternion.Euler(Input.GetAxis("Horizontal") * move * roatation_speed * Time.fixedDeltaTime);
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
                GameObject newBarrier = Instantiate(barrier_prefab, transform.position + new Vector3(0, 1, 0), body.transform.rotation * Quaternion.Euler(new Vector3(0, 90, 0)));
                newBarrier.layer = LayerMask.NameToLayer("Barrier");
                distance = 30;
                canPlaceBarrier = false;
                line.positionCount += 1;
                line.SetPosition(line.positionCount - 1, transform.position);
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        print(collider.gameObject.layer);
        if (!ends && collider.gameObject.layer == 10 && isPlaying)
        {
            ends = true;
            Vector3[] vectors = new Vector3[line.positionCount];
            Vector3 midOilPoint = new Vector3(-873f, -2.3f, -937f);
            line.GetPositions(vectors);
            if (PolygonIsContainPoint(midOilPoint, vectors)) {
                StartEnd.GetComponent<Renderer>().sharedMaterial = materials[2];
                print("end");
                canvas.SetActive(true);
                Step2.SetActive(true);
            } else
            {
                canvas.SetActive(true);
                GameOver.SetActive(true);
                print("fail");

            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (!isPlaying && collider.gameObject.layer == 10)
        {
            isPlaying = true;
            StartEnd.GetComponent<Renderer>().sharedMaterial = materials[1];
        }
    }

    public static bool PolygonIsContainPoint(Vector3 point, Vector3[] vertexs)
    {
        int leftNum = 0;
        int rightNum = 0;
        int index = 1;

        for (int i = 0; i < vertexs.Length; i++)
        {
            if (i == vertexs.Length - 1)
            {
                index = -i;
            }

            if (point.z >= vertexs[i].z && point.z < vertexs[i + index].z ||
                point.z < vertexs[i].z && point.z >= vertexs[i + index].z)
            {
                Vector3 vecNor = (vertexs[i + index] - vertexs[i]);

                if (vecNor.x == 0.0f)
                {
                    if (vertexs[i].x < point.x)
                    {
                        leftNum++;
                    }
                    else if (vertexs[i].x == point.x)
                    {
                    }
                    else
                    {
                        rightNum++;
                    }
                }
                else
                {
                    vecNor = vecNor.normalized;
                    float k = vecNor.z / vecNor.x;
                    float b = vertexs[i].z - k * vertexs[i].x;

                    if ((point.z - b) / k < point.x)
                    {
                        leftNum++;
                    }
                    else if ((point.z - b) / k == point.x)
                    {
                    }
                    else
                    {
                        rightNum++;
                    }
                }
            }
        }
        print((leftNum, rightNum));
        if (leftNum % 2 != 0 || rightNum % 2 != 0)
        {
            return true;
        }

        return false;
    }
}


