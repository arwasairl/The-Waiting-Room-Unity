/////////////////////////////////////////////////////////
//
// Copyright (c) 2025 by arwasairl
//
// This source is provided under the MIT license.
// This software is provided WITHOUT A WARRANTY.
//
// WHAT: Object detection for the room and lamp/siren initiator
// DEFINED EXTERNS: OnCollision
// RETURNS: line 58 (void return), line 88 (void return)
//
/////////////////////////////////////////////////////////

using UnityEngine;
using System;

public class Detection : MonoBehaviour
{
    public AudioSource otherAudioSource;
    public Light lamp1;
    public Light lamp2;
    public Transform rotatingBeacon;
    public Vector3 rotationSpeed = new Vector3(0, 100, 0);
    public static event Action<GameObject> OnCollision;

    void Start()
    {
        lamp1.enabled = false;
        lamp2.enabled = false;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision == null && GlobalVar.breakerFail == true)
        {
            GlobalVar.nukeImminent = true;
            AudioSource[] allAudioSources = FindObjectsByType<AudioSource>(FindObjectsSortMode.None);

            foreach (AudioSource audioSource in allAudioSources)
            {
                if (audioSource.gameObject.name != "lightBuzzSFX")
                {
                    audioSource.Stop();
                }
            }
            GameObject otherObject = GameObject.Find("roomSpeaker");
            if (otherObject != null)
            {
                AudioSource otherAudioSource = otherObject.GetComponent<AudioSource>();
                if (otherAudioSource != null)
                {
                    AudioClip newClip = Resources.Load<AudioClip>("Audio/nukeWarning");
                    otherAudioSource.clip = newClip;
                    otherAudioSource.Play();
                }
            }
            lamp1.enabled = !lamp1.enabled;
            lamp2.enabled = !lamp2.enabled;
            return;
        }


        if (collision.gameObject.CompareTag("Walls") && GlobalVar.nukeImminent != true && GlobalVar.doorOpen != true)
        {
            GlobalVar.nukeImminent = true;
            AudioSource[] allAudioSources = FindObjectsByType<AudioSource>(FindObjectsSortMode.None);

            foreach (AudioSource audioSource in allAudioSources)
            {
                if (audioSource.gameObject.name != "lightBuzzSFX")
                {
                    audioSource.Stop();
                }
            }
            GameObject otherObject = GameObject.Find("audtioScript");
            if (otherObject != null)
            {
                AudioSource otherAudioSource = otherObject.GetComponent<AudioSource>();
                if (otherAudioSource != null)
                {
                    AudioClip newClip = Resources.Load<AudioClip>("Audio/nukeWarning");
                    otherAudioSource.clip = newClip;
                    otherAudioSource.Play();
                }
            }
            lamp1.enabled = !lamp1.enabled;
            lamp2.enabled = !lamp2.enabled;
            OnCollision?.Invoke(collision.gameObject);
            return;
        }
    }
    void Update()
    {
        if (GlobalVar.breakerFail == true && GlobalVar.nukeImminent == false && GlobalVar.doorOpen == false)
        {
            OnCollisionEnter(null);
        }
        rotatingBeacon.Rotate(rotationSpeed * Time.deltaTime);
    }
}
