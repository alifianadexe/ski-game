using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [Tooltip("Sound to play when the player character is hit")]
    public AudioClip collisionSound;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        PlayerEvents.OnPlayerHit += PlayCollisionSound;
    }

    private void OnDisable()
    {
        PlayerEvents.OnPlayerHit -= PlayCollisionSound;
    }

    private void PlayCollisionSound()
    {
        audioSource.PlayOneShot(collisionSound);
    }
}
