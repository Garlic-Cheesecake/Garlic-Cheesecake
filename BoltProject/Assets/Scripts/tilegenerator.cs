using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

public class tilegenerator : MonoBehaviour
{
    [SerializeField]private List<GameObject> tiles;
    [SerializeField]private GameObject roundText;
    [SerializeField]private GameObject questionText;
    public gameManager gm;

    private string[] questionTextList = new string[5];
    private string[] attributesList = new string[20];
    private int[] a = new int[4];
    private int[] b = new int[4];

    public bool[] selectedTiles = new bool[2];

    private int selectCount = 0;
    private int attributeListCount = 0;
    private bool f = false;
    
    string filePath;



    // Start is called before the first frame update
    void Start()
    {   
        filePath = "Assets/Files/" + gameManager.gameMode + ".txt";

        Debug.Log(gameManager.gameMode);

        int i = 0;
        while(i < 4) {
            a[i] = i;
            i++;
        }        

        tiles[0].GetComponent<tile>().pressKey = KeyCode.A;
        tiles[1].GetComponent<tile>().pressKey = KeyCode.S;
        tiles[2].GetComponent<tile>().pressKey = KeyCode.D;
        tiles[3].GetComponent<tile>().pressKey = KeyCode.F;

        i = 0;

        // foreach(GameObject t in tiles) {
        //     Debug.Log(t.GetComponent<tile>().isCorrectAnswer());
        // }

        readFromFile();
        generateTiles(); 

    }

    // Update is called once per frame
    void Update()
    {
        
        if(selectCount == 2) {
            if(selectedTiles[0] && selectedTiles[1]) {
                // add point
                gm.stopTicking();
                StartCoroutine(roundPause());
                if(f) {
                    StopAllCoroutines();
                    gm.addPoint();
                    f = false;
                }
            }

            else {
                gm.stopTicking();
                StartCoroutine(roundPause());
                if(f) {
                    StopAllCoroutines();
                    gm.setRoundOver();
                    f = false;
                }
            }
        }
    }

    private IEnumerator roundPause() {
        yield return new WaitForSeconds(.5f);

        f = true;
    }

    void readFromFile() {
        // Read the file line by line
        StreamReader reader = new StreamReader(filePath);

        string line;
        int k = 0;
        int l = 0;

        while((line = reader.ReadLine()) != null) {
            questionTextList[k] = line;

            int i = 0;
            while(i < 4) {
                attributesList[l++] = reader.ReadLine();
                i++;
            }

            k++;
        }

        gm.setMaxRounds(k);
        reader.Close();
    }

    private void generateTiles() {
        b =  a.OrderBy(x => Random.value).ToArray();
        int i = 0;
        while(i < 4) {
            // Debug.Log(b[i]);

            if(b[i] == 0 || b[i] == 1) {
                tiles[i].GetComponent<tile>().setCorrect(true);
            }

            i++;
        }

        roundText.GetComponent<TextMeshPro>().text = "Round " + (gm.getRound()+1);

        questionText.GetComponent<TextMeshPro>().text = questionTextList[gm.getRound()];

        for(i = 0; i < 4; i++) {
            // Debug.Log(attributesList[attributeListCount+b[i]]);
            tiles[i].GetComponent<tile>().updateText(attributesList[attributeListCount+b[i]]);
        }
        attributeListCount += 4;
    }

    public void upCount() {
        selectCount++;
    }

    public int getCount() {
        return selectCount;
    }

    public void callTileGeneration() {
        generateTiles();
    }

    public void resetTiles() {
        for(int i = 0; i < 4; i++) {
            tiles[i].GetComponent<tile>().resetTile();
        }

        selectCount = 0;
    }
}
