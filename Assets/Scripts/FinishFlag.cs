using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishFlag : MonoBehaviour
{

    public void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            GameEvents.StopRace();
        }
    }

}
