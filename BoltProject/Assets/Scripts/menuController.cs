using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class menuController : MonoBehaviour
{
    [SerializeField]private GameObject title;
    [SerializeField]private GameObject nextTitlePos;
    [SerializeField]private GameObject music;

    // buttons
    [SerializeField]private GameObject playB;
    [SerializeField]private GameObject sixB;
    [SerializeField]private GameObject sevenB;
    [SerializeField]private GameObject eightB;
    [SerializeField]private GameObject iqb;
    [SerializeField]private GameObject mathB;
    [SerializeField]private GameObject scienceB;

    private int selectedLevel;
    private string selectedSub;

    // Start is called before the first frame update
    void Start()
    {
        sixB.SetActive(false);
        sevenB.SetActive(false);
        eightB.SetActive(false);
        mathB.SetActive(false);
        scienceB.SetActive(false);
        iqb.SetActive(false);

        DontDestroyOnLoad(music);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onPlay() {
        title.transform.position = nextTitlePos.transform.position;
        playB.SetActive(false);

        sixB.SetActive(true);
        sevenB.SetActive(true);
        eightB.SetActive(true);
        iqb.SetActive(true);
    }

    public void onLevel(int level) {
        selectedLevel = level;

        if(level == 0) {
            gameManager.gameMode = "iquiz";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        }

        sixB.SetActive(false);
        sevenB.SetActive(false);
        eightB.SetActive(false);
        iqb.SetActive(false);

        mathB.SetActive(true);
        scienceB.SetActive(true);
    }

    public void onSubject(int sub) {

        if(sub == 0) {
            selectedSub = "math";
        } else {
            selectedSub = "science";
        }

        gameManager.gameMode = selectedSub + selectedLevel;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
