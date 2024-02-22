using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class tile : MonoBehaviour
{
    [SerializeField]private String attributeText;
    public KeyCode pressKey;

    private bool isSelected;
    private bool isCorrect;

    // Start is called before the first frame update
    void Start()
    {
        isSelected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isSelected) {
            checkInput();
        }
    }

    public void updateText(string text) {
        this.attributeText = text;
    }

    public void checkInput() {
        if(Input.GetKey(pressKey)) {
            isSelected = true;
            Debug.Log("KeyPressed");
        }
    }
}
