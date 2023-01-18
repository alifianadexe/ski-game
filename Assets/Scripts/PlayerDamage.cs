using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [Tooltip("How much force knocks the player backwards")]
    public float knockbackForce;

    [Tooltip(
        "How much seconds before the player can move downhill again after crashing into obstacle"
    )]
    public float recoveryTime;

    [Tooltip("Checks when the player is hurt ")]
    public bool hurt = false;

    private Rigidbody rb;

    // register TakeDamage void when OnPlayerHit events
    private void OnEnable()
    {
        PlayerEvents.OnPlayerHit += TakeDamage;
    }

    // unreg TakeDamage void when OnPlayerHit events
    private void OnDisable()
    {
        PlayerEvents.OnPlayerHit -= TakeDamage;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void TakeDamage()
    {
        if (!hurt)
        {
            hurt = true;
            rb.velocity = Vector3.zero;

            // sends players back bumping
            rb.AddForce(transform.forward * -knockbackForce);
            rb.AddForce(transform.up * 500);

            StartCoroutine("Recover");
        }
    }

    IEnumerator Recover()
    {
        yield return new WaitForSeconds(recoveryTime);
        hurt = false;
    }
}
