using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameManager : MonoBehaviour
{
    [SerializeField]private int points;

    [SerializeField]private tilegenerator tilegen;
    [SerializeField]private GameObject pointsText;
    [SerializeField]private GameObject timerText;

    private bool isRoundOver;

    private int timer;
    private int roundNum;

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        isRoundOver = false;
        timer = 4;
        roundNum = 0; 

        StartCoroutine(tickTimer());
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.GetComponent<TextMeshPro>().text = "POINTS: " + points;
        timerText.GetComponent<TextMeshPro>().text = "CLOCK\n" + timer;
    }

    public void addPoint() {
        if(!isRoundOver) {
            points++;
            isRoundOver = true;
            timer = 0;
        }
    }

    public int getRound() {
        return roundNum;
    }

    private IEnumerator gameOver() {

        yield return new WaitForSeconds(5);

        // nextRound
        Application.Quit();

        // if roundNum is 5, show exit screen
    }

    private IEnumerator tickTimer() {
        while(timer > 0) {
            yield return new WaitForSeconds(1);
            timer -= 1;
        }

        StartCoroutine(gameOver());
    }
}
