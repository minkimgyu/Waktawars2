using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public SetUp setUp;
    public TextMeshProUGUI timerTxt;
    public Scrollbar scrollbar;
    public float time = 0;

    public bool nowStart = false;

    public void NowStart(bool start) => nowStart = start;

    public void StopGame()
    {
        if (nowStart == false) return;
        AudioManager.instance.StopBGM();

        time = 0;
        scrollbar.value = 0;
        timerTxt.text = "";
        nowStart = false;
    }

    public void PauseGame()
    {
        if (nowStart == false) return;
        AudioManager.instance.StopBGM();

        nowStart = false;
    }

    public void StartGame()
    {
        if (nowStart == false) return;

        AudioManager.instance.PlayBGM("Eight");

        time += Time.deltaTime;
        scrollbar.value = (time / 1000) / setUp.maxTime * 1000;

        timerTxt.text = time.ToString("F5"); // 1.23


        //60000 

        // 1 / 60000 --> 1ms
        // 1초당 1 / 60 만큼 value를 이동
    }

    private void Update()
    {
        StartGame();
    }
}
