using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{

    public delegate void raceAction();

    public static event raceAction OnRaceStart;
    public static event raceAction OnRaceStop;

    public static void StartRace(){
        if(OnRaceStart != null){
            OnRaceStart();
        }
    }

    public static void StopRace(){
        if(OnRaceStop != null){
            OnRaceStop();
        }
    }

}

