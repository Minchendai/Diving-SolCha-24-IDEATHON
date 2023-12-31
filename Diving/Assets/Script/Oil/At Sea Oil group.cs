using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtSeaOilgroup : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] oils;
    public GameObject finish;
    public GameObject canvas;
    public GameObject game;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool isGameOver = true;
        foreach(GameObject oil in oils) {
            if (!isGameOver) break;
            if (oil.activeSelf) isGameOver = false;
        }
        if (isGameOver)
        {
            print("GameOver");
            canvas.SetActive(true);
            finish.SetActive(true);
            game.SetActive(false);
        }
    }
}
