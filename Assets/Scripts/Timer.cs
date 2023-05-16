using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    public TMP_Text timeText;
    public GameObject wrongText;

    public float elapsedTime = 60f; // Elapsed time in seconds
    public bool start;
    public bool win;
    public GameObject music;

    public Detection detection;
    void Start()
    {
        win = false;
        wrongText.SetActive(false);
    }

    void Update()
    {
        if (start == true)
        {
            elapsedTime -= Time.deltaTime;

            if (elapsedTime >= 0)
            {
                timeText.text = elapsedTime.ToString("f1");
                if (win)
                {
                    timeText.text = "You are a pro!";
                    Destroy(music);
                }
            }
            else
            {
                timeText.text = "Time's up!";
            }

            if(detection.ifEnd == true &&win == false)
            {
                wrongText.SetActive(true);
            }
            else
            {
                wrongText.SetActive(false);
            }
        }

  
    }

    public void StartGame()
    {
        start = true;

    }

}
