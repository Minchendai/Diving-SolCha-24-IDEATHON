using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIButton : MonoBehaviour
{
    public GameObject backGround;
    public GameObject Game;
    public GameObject Step1;

    public void ButtonPressed()
    {
        backGround.SetActive(false);
        Game.SetActive(true);
        Step1.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
