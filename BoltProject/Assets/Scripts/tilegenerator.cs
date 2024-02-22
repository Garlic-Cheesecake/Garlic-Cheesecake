using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class tilegenerator : MonoBehaviour
{
    [SerializeField]private tile[] tiles = new tile[4];

    private string[] attributes = new string[4];
    private int[] a = new int[4];


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
            i++;
        }

        tiles[0].pressKey = KeyCode.A;
        tiles[1].pressKey = KeyCode.S;
        tiles[2].pressKey = KeyCode.D;
        tiles[3].pressKey = KeyCode.F;

        attributes[0] = "First attribute";
        attributes[1] = "Second attribute";
        attributes[2] = "Third attribute";
        attributes[3] = "Fourth attribute";

        i = 0;

        foreach(tile t in tiles) {
            t.updateText(attributes[b[i]]);
            if(i == 0 || i == 1) {
                t.setCorrect(true);
            }
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void generateTiles() {
        
    }

    void readFromFile() {
        string filePath = "Assets/Files/input.txt";
        
        if(File.Exists(filePath)) {
            StreamReader reader = new StreamReader(filePath);

            string line = reader.ReadLine();
            // while(line != null) {
            //     tiles[t++].updateText(line);
                
            // }
        }
        else {
            Debug.Log("FILE PATH ERROR");
        }
    }
}
