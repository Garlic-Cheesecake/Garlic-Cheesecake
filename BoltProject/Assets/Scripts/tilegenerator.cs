using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class tilegenerator : MonoBehaviour
{
    [SerializeField]private tile[] tiles = new tile[4];


    // Start is called before the first frame update
    void Start()
    {   
        tiles[0].pressKey = KeyCode.A;
        tiles[1].pressKey = KeyCode.S;
        tiles[2].pressKey = KeyCode.D;
        tiles[3].pressKey = KeyCode.F;

        readFromFile();
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
            int t = 0;
            // while(line != null) {
            //     tiles[t++].updateText(line);
                
            // }
        }
        else {
            Debug.Log("FILE PATH ERROR");
        }
    }
}
