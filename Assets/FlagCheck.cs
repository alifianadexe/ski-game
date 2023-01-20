using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagCheck : MonoBehaviour
{
    public enum Direction {Left, Right};
    public Direction passingDirection;
    public Material passedFlagMat, failedFlagMat;
    public GameObject childObj;

    private void OnTriggerExit(Collider other){
        if(other.tag == "Player"){
            float dirCheck = transform.position.x + other.transform.position.x;

            if(passingDirection == Direction.Left){
                if(other.transform.position.x < transform.position.x){
                    PassSuccessfull();
                }else{
                    PassUnSuccessfull();
                }
            }

            if(passingDirection == Direction.Right){
                if(other.transform.position.x > transform.position.x){
                    PassSuccessfull();
                }else{
                    PassUnSuccessfull();
                }
            }

        }
    }

    private void PassSuccessfull(){
        childObj.GetComponent<MeshRenderer>().material = passedFlagMat;
    }

    private void PassUnSuccessfull(){
        childObj.GetComponent<MeshRenderer>().material = failedFlagMat;

        RaceTimer.time += 1;
    }

}
