using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIButton : MonoBehaviour
{
    public GameObject backGround;
    public GameObject Game;
    public GameObject Step1;
    public AudioClip init;
    public AudioClip inGame;
    public GameObject mainCamera;

    public void ButtonPressed()
    {
        backGround.SetActive(false);
        Game.SetActive(true);
        Step1.SetActive(true);
        mainCamera.GetComponent<AudioSource>().clip = inGame;
        mainCamera.GetComponent<AudioSource>().loop = true;
        mainCamera.GetComponent<AudioSource>().Play();
    }
    // Start is called before the first frame update
    void Start()
    {
        mainCamera.GetComponent<AudioSource>().clip = init;
        mainCamera.GetComponent<AudioSource>().loop = true;
        mainCamera.GetComponent<AudioSource>().Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
