using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class filemanager : MonoBehaviour
{
    private ProcessStartInfo startInfo1 = new ProcessStartInfo();
    private ProcessStartInfo startInfo2 = new ProcessStartInfo();
    private ProcessStartInfo startInfo3 = new ProcessStartInfo();

    private Process p1;
    private Process p2;
    private Process p3;

    private bool f = false;
    private bool f2 = false;

    void Start() {
        startInfo1.FileName = "converter.exe";
        startInfo2.FileName = "gpt4.exe";
        startInfo3.FileName = "removeemptylines.exe";
    }
    
    void Update() {
        // if(f) {
        //     if(p1.HasExited) {
        //         p2 = Process.Start(startInfo2);
        //     }

        //     f2 = true;
        //     f = false;
        // }

        // if(f2) {
        //     if(p2.HasExited) {
        //         p3 = Process.Start(startInfo3);
        //     }

        //     f2 = false;
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // }
    }

    public void callIquiz() {
        p1 = Process.Start(startInfo1);
        f = true;

        StartCoroutine(runSecondProcess());
    }

    private IEnumerator runSecondProcess() {

        yield return new WaitForSeconds(5);

        p1 = Process.Start(startInfo2);

        // StartCoroutine(runThirdProcess());

    }
}
