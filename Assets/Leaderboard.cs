using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public string[] formattedTimes;
    private List<float> savedTimes = new List<float>(new float[5]);
 

    private void OnEnable()
    {
        GameEvents.OnRaceStop += CheckRaceTime; 
    }

    private void OnDisable()
    {
        GameEvents.OnRaceStop -= CheckRaceTime;
    }

    private void Start()
    {
        CheckIfPrefsSet();
        GetBestTimes();
        PlayerPrefs.DeleteAll();
    }

    private void GetBestTimes()
    {
        if (PlayerPrefs.HasKey("fastTime1"))
            savedTimes[0] = PlayerPrefs.GetFloat("fastTime1");

        if (PlayerPrefs.HasKey("fastTime2"))
            savedTimes[1] = PlayerPrefs.GetFloat("fastTime2");

        if (PlayerPrefs.HasKey("fastTime3"))
            savedTimes[2] = PlayerPrefs.GetFloat("fastTime3");

        if (PlayerPrefs.HasKey("fastTime4"))
            savedTimes[3] = PlayerPrefs.GetFloat("fastTime4");

        if (PlayerPrefs.HasKey("fastTime5"))
            savedTimes[4] = PlayerPrefs.GetFloat("fastTime5");

        FormatTimesToString();
    }

    private void SetBestTimes()
    {
        PlayerPrefs.SetFloat("fastTime1", savedTimes[0]);

        PlayerPrefs.SetFloat("fastTime2", savedTimes[1]);

        PlayerPrefs.SetFloat("fastTime3", savedTimes[2]);

        PlayerPrefs.SetFloat("fastTime4", savedTimes[3]);

        PlayerPrefs.SetFloat("fastTime5", savedTimes[4]);

        FormatTimesToString();
    }

    private void CheckRaceTime()
    {
        //set the initial position out of range
        int scorePosition = 99;
        //flag to see if we got a highscore
        bool highScore = false;

        //Loop backwards through the savedTimes and check if we have beaten any times
        for (int i = 4; i >= 0; i--)
        {
            //check time and also check if time slot is unsaved/0
            if (RaceTimer.time < savedTimes[i]||savedTimes[i]==0)
            {
                highScore = true;
                //if i is less than our current position make that our current position
                if (i < scorePosition)
                    scorePosition = i;
            }
        }

        //If we have a high score, insert it into our times list and then Set the New Best Times player prefs
        if (highScore)
        {
            savedTimes.Insert(scorePosition, RaceTimer.time);
            SetBestTimes();
           

        }
    }

    //
    private void FormatTimesToString()
    {
        for (int i = 4; i >= 0; i--)
        {
            TimeSpan t = TimeSpan.FromSeconds(savedTimes[i]);
            formattedTimes[i] = t.ToString("m':'ss':'ff");

        }
    }

    private void CheckIfPrefsSet()
    {
            for (int i = 0; i <= 5; i++)
            {
                //if we don't have our PlayerPrefs set them up with a default value of 0
                if (!PlayerPrefs.HasKey("fastTime" + i.ToString()))
                {
                    PlayerPrefs.SetFloat("fastTime" + i.ToString(), 0);
                }
            }  
    }
}
