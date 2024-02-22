using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class points : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshPro>().text = "Points: " + gameManager.points;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            Application.Quit();
        }
    }
}
