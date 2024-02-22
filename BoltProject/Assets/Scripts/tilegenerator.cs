using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

public class tilegenerator : MonoBehaviour
{
    [SerializeField]private tile[] tiles = new tile[4];
    [SerializeField]private GameObject roundText;
    [SerializeField]private GameObject questionText;
    public gameManager gm;

    private List<string> questionTextList;
    private List<string> attributesList;
    private int[] a = new int[4];

    public bool[] selectedTiles = new bool[2];

    private int selectCount = 0;
    string filePath = "Assets/Files/input.txt";


    // Start is called before the first frame update
    void Start()
    {   
        int i = 0;
        while(i < 4) {
            a[i] = i;
            i++;
        }

        int[] b =  a.OrderBy(x => Random.value).ToArray();
        i = 0;
        while(i < 4) {
            Debug.Log(b[i]);

            if(b[i] == 0 || b[i] == 1) {
                tiles[i].setCorrect(true);
            }

            i++;
        }

        tiles[0].pressKey = KeyCode.A;
        tiles[1].pressKey = KeyCode.S;
        tiles[2].pressKey = KeyCode.D;
        tiles[3].pressKey = KeyCode.F;

        i = 0;

        foreach(tile t in tiles) {
            Debug.Log(t.isCorrectAnswer());
        }

        readFromFile();
        generateTiles();

    }

    // Update is called once per frame
    void Update()
    {
        if(selectCount == 2) {
            if(selectedTiles[0] && selectedTiles[1]) {
                // add point
                gm.addPoint();
            }
        }
    }

    void readFromFile() {
        // Read the file line by line
        string[] lines = File.ReadAllLines(filePath);

        // Process each line
        int lineNumber = 0;
        int k = 0;
        int l = 0;
        foreach(string line in lines){
            if (lineNumber % 5 == 0){
                questionTextList.Add(line);
            }
            else{
                attributesList.Add(line);
            }
            lineNumber++;
        }
    }

    void generateTiles() {
        roundText.GetComponent<TextMeshPro>().text = "Round " + (gm.getRound()+1);

        questionText
    }

    public void upCount() {
        selectCount++;
    }

    public int getCount() {
        return selectCount;
    }
}
