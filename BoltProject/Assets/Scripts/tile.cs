using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class tile : MonoBehaviour
{
    [SerializeField]private GameObject attributeText;
    [SerializeField]public KeyCode pressKey;
    [SerializeField]private GameObject greenBG; 

    [SerializeField]private tilegenerator tilegen;

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
        attributeText.GetComponent<TextMeshPro>().text = text;
    }

    public void setCorrect(bool c) {
        isCorrect = c;
    }

    public void checkInput() {
        // Debug.Log(tilegen.getCount());
        if(Input.GetKey(pressKey) && tilegen.getCount() < tilegen.getMaxCount() && !tilegen.getInputFlag()) {
            isSelected = true;
            greenBG.SetActive(true);
            Debug.Log(tilegen.getCount());
            tilegen.selectedTiles[tilegen.getCount()] = isCorrect;
            tilegen.upCount();
        }
    }

    public bool isCorrectAnswer() {
        return isCorrect;
    }

    public void resetTile() {
        greenBG.SetActive(false);
        isSelected = false;
        isCorrect = false;
    }
}
