using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Oculus.Interaction.Grabbable;

public class GrabbableAudioPlayer : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private AudioSource _audioSource;
    public AudioClip rollingSound;

    private void Awake()
    {
        // Ensure the Rigidbody and AudioSource are assigned
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();

        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
        }

        if (rollingSound != null)
        {
            _audioSource.clip = rollingSound;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Only play the sound if the dice is moving and not kinematic
        if (!_rigidbody.isKinematic && _rigidbody.velocity.magnitude > 0.1f)
        {
            PlayRollingSound();
        }
    }

    private void PlayRollingSound()
    {
        // Play the dice rolling sound
        if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
        }
    }
}
