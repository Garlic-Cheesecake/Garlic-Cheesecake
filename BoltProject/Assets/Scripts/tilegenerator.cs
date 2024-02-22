using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tilegenerator : MonoBehaviour
{
    public tile[] tiles = new tile[8];

    // Start is called before the first frame update
    void Start()
    {
        tiles[0].pressKey = KeyCode.A;
        tiles[1].pressKey = KeyCode.S;
        tiles[2].pressKey = KeyCode.D;
        tiles[3].pressKey = KeyCode.F;
        tiles[4].pressKey = KeyCode.J;
        tiles[5].pressKey = KeyCode.K;
        tiles[6].pressKey = KeyCode.L;
        tiles[7].pressKey = KeyCode.Semicolon;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void generateTiles() {

    }
}
