using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTimer : MonoBehaviour
{
    public bool raceStarted = false;
    public static float time = 0;
    private TimeSpan timePlaying;

    private void OnEnable(){
        GameEvents.OnRaceStart += StartTimer;
        GameEvents.OnRaceStop += StopTimer;
    }

    private void OnDisable(){
        GameEvents.OnRaceStart -= StartTimer;
        GameEvents.OnRaceStop -= StopTimer;
    }

    private void StartTimer(){
        time = 0;
        StartCoroutine("Timer");
        raceStarted = true;
    }

    private void StopTimer(){
        if(raceStarted){
            StopCoroutine("Timer");
            print("RACE TIME: " + timePlaying.ToString("mm':'ss':'ff"));
        }
    }

    private IEnumerator Timer(){
        while(true){
            time += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(time);
            yield return null;
        }
    }
}
