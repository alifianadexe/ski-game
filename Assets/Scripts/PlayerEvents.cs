using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    public delegate void playerHitAction();
    public static event playerHitAction OnPlayerHit;
    public Camera cmFreeCam;

    public static void PlayerHit()
    {
        if (OnPlayerHit != null)
        {
            OnPlayerHit();
        }
    }
}
