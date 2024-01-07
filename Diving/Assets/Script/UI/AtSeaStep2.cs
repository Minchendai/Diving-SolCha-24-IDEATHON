using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtSeaStep2 : MonoBehaviour
{
    public GameObject ths;
    public GameObject canvas;
    public GameObject vacuum;
    public string[] text;
    public GameObject textField;
    private int cur = 0;

    public void ButtonPressed()
    {
        if (cur < text.Length)
        {
            textField.GetComponent<TMPro.TMP_Text>().text = text[cur];
            cur += 1;
        } else
        {
            ths.SetActive(false);
            canvas.SetActive(false);
            vacuum.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(true);
        textField.GetComponent<TMPro.TMP_Text>().text = text[cur];
        cur += 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
