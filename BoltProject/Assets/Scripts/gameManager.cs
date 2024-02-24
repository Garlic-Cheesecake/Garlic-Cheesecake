using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public static int points;

    public static string gameMode;

    [SerializeField]private tilegenerator tilegen;
    [SerializeField]private GameObject pointsText;
    [SerializeField]private GameObject timerText;

    private bool isPoint;
    private bool isRoundOver;

    private int timer;
    private int roundNum;
    private int maxRounds;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().Play();

        points = 0;
        isPoint = false;
        timer = 4;
        roundNum = 0;

        StartCoroutine(tickTimer());
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.GetComponent<TextMeshPro>().text = "POINTS: " + points;
        timerText.GetComponent<TextMeshPro>().text = "CLOCK\n" + timer;

        if(isRoundOver) {
            roundOver();
            isRoundOver = false;
        }
    }

    public void addPoint() {
        if(!isPoint) {
            points++;
            isRoundOver = true;
            
            roundOver();
        }
    }

    public int getRound() {
        return roundNum;
    }

    private IEnumerator gameOver() {

        yield return new WaitForSeconds(5);

        // nextRound
        Application.Quit();
    }

    public void roundOver() {
        roundNum++;

        if(roundNum >= maxRounds) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        else {
            timer = 5;
            tilegen.resetTiles();
            tilegen.callTileGeneration();
            isRoundOver = false;
            StartCoroutine(tickTimer());
        }
    }

    private IEnumerator tickTimer() {
        while(timer > 0) {
            yield return new WaitForSeconds(1);
            timer -= 1;
        }

        isRoundOver = true;
    }

    public void setMaxRounds(int k) {
        maxRounds = k;
    }

    public void stopTicking() {
        StopAllCoroutines();
    }

    public void setRoundOver() {
        isRoundOver = true;
    }
}
