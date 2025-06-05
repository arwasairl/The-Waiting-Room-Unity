/////////////////////////////////////////////////////////
//
// Copyright (c) 2025 by arwasairl
//
// This source is provided under the MIT license.
// This software is provided WITHOUT A WARRANTY.
//
// WHAT: Audio Manager for narrator voicelines only
// DEFINED EXTERNS: PlayAudio()
// RETURNS: 0
//
/////////////////////////////////////////////////////////

using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public enum AudioType
{
    INTRO,
    NAR1,
    NAR2,
    NAR3,
    NAR4,
    NAR5,
    NAR6,
    NAR7,
    NAR8,
    NAR9,
    NAR10a,
    NAR10b
}

[RequireComponent (typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioList;
    private static AudioManager instance;
    private AudioSource audiosource;
    public string audioTypeCompleted;
    void Start()
    {
        Invoke("PlayPM1", 5.0f);
        StartCoroutine(AudioFinished());
    }
    private void Awake()
    {
        instance = this;
    }

    public static void PlayAudio(AudioType audio, float volume = 1)
    {
        instance.audiosource.PlayOneShot(instance.audioList[(int)audio], volume);
    }
    IEnumerator AudioFinished()
    {
        if (instance.audiosource == null)
        {
            yield break;
        }
        else
        {
            while (instance.audiosource.isPlaying)
            {
                yield return null;
            }
            Debug.Log("Done!");
        }
    }
    void PlayPM1()
    {
        if (GlobalVar.nukeImminent != true)
        {
            PlayAudio(AudioType.INTRO, 1);
        }
    }
}
