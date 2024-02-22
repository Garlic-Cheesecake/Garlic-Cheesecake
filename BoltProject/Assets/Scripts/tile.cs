using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class tile : MonoBehaviour
{
    [SerializeField]private String attributeText;
    [SerializeField]public KeyCode pressKey;
    [SerializeField]private GameObject greenBG;

    private tilegenerator tilegen;

    [SerializeField]private bool isSelected;
    [SerializeField]private bool isCorrect;

    // Start is called before the first frame update
    void Start()
    {
        isSelected = false;

        tilegen = GetComponentInParent<tilegenerator>();
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

    public void setCorrect(bool c) {
        isCorrect = c;
    }

    public void checkInput() {
        if(Input.GetKey(pressKey) && gameObject.GetComponentInParent<tilegenerator>().getCount() < 2) {
            isSelected = true;
            greenBG.SetActive(true);
            tilegen.selectedTiles[tilegen.getCount()] = isCorrect;
            tilegen.upCount();
            
        }
    }

    public bool isCorrectAnswer() {
        return isCorrect;
    }
}
