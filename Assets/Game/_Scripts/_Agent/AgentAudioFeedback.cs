using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAudioFeedback : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] AudioClip clip;
    [SerializeField] float pitchRandomness;

    private float basePitch;

    private void Awake()
    {
        audioSource = this.GetComponentInParent<AudioSource>();
    }

    private void Start()
    {
        basePitch = audioSource.pitch;
    }

    public void OnFeedback()
    {
        var randomPitch = Random.Range(-pitchRandomness, pitchRandomness);
        audioSource.pitch = basePitch + randomPitch;

        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }
}
