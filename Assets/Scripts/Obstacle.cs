using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            HitPlayer(collision.gameObject);
        }
    }

    public virtual void HitPlayer(GameObject player)
    {
        PlayerEvents.PlayerHit();
    }
}
