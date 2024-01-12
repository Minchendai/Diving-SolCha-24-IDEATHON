using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnShoreDialog : MonoBehaviour
{
    public TextMeshProUGUI message;
    public GameObject dialogContainer;
    public GameObject toolkit;
    public GameObject vacuum;
    public GameObject shovel;
    public GameObject sponge;
    public GameObject biodegrader;
    public GameObject stop;
    public string[] messagePool;
    private int index=0;
    
    public void ChangeDialog() {
        if (index<messagePool.Length) {
            message.text = messagePool[index];
            if (messagePool[index].Contains("vacuum")) {
                toolkit.SetActive(true);
                vacuum.SetActive(true);
            } else if (messagePool[index].Contains("sponge")) {
                sponge.SetActive(true);
            } else if (messagePool[index].Contains("shovel")) {
                shovel.SetActive(true);
            } else if (messagePool[index].Contains("biodegra")) {
                biodegrader.SetActive(true);
            } else if (messagePool[index].Contains("Loading")) {
                dialogContainer.SetActive(false);
                stop.SetActive(false);
                if (index>5) {
                    vacuum.SetActive(false);
                }
                if (index>7) {
                    sponge.SetActive(false);
                }
                CleanUpScene();
                message.text = messagePool[index];
            }
            index++;
        } else {
            index = messagePool.Length;
        }
    }

    private void CleanUpScene() {
        while (GameObject.FindWithTag("Shovel")) {
            GameObject.FindWithTag("Shovel").SetActive(false);
        }
        while (GameObject.FindWithTag("Sponge")) {
            GameObject.FindWithTag("Sponge").SetActive(false);
        }
    }

    private void Update() {
    }
}