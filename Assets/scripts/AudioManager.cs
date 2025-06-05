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
    NAR2,
    NAR3,
    NAR4,
    NAR5,
    NAR6,
    NAR7,
    NAR8,
    NAR9,
    NAR10,
    NAR11,
    NAR12,
    NAR13,
    NAR14,
    NAR15,
    NAR16,
    NAR17,
    NARHEY,
    NAR18,
    NAR19,
    NAR20
}

[RequireComponent (typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioList;
    public AudioSource audiosource;
    public string audioTypeCompleted;
    private AudioType currentType;
    void Start()
    {
        Invoke("PlayPM1", 5.0f);
    }
    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
    }

    public AudioType PlayAudio(AudioType audio, float volume = 0.60f)
    {
        audiosource.PlayOneShot(audioList[(int)audio], volume);
        return currentType = audio;
    }

    public IEnumerator WaitForAudioToEnd()
    {
        yield return new WaitWhile(() => audiosource.isPlaying);
        if (GlobalVar.nukeImminent != true)
        {
            if (GlobalVar.narratorCutoff == false)
            {
                switch (currentType.ToString())
                {
                    case "INTRO":
                        GetComponent<AudioManager>().PlayAudio(AudioType.NAR2, 0.65f);
                        StartCoroutine(WaitForAudioToEnd());
                        break;
                    case "NAR2":
                        GetComponent<AudioManager>().PlayAudio(AudioType.NAR3, 0.65f);
                        StartCoroutine(WaitForAudioToEnd());
                        break;
                    case "NAR3":
                        GetComponent<AudioManager>().PlayAudio(AudioType.NAR4, 0.65f);
                        StartCoroutine(WaitForAudioToEnd());
                        break;
                    case "NAR4":
                        GetComponent<AudioManager>().PlayAudio(AudioType.NAR5, 0.65f);
                        StartCoroutine(WaitForAudioToEnd());
                        break;
                    case "NAR5":
                        GetComponent<AudioManager>().PlayAudio(AudioType.NAR6, 0.65f);
                        StartCoroutine(WaitForAudioToEnd());
                        break;
                    case "NAR8":
                        GetComponent<AudioManager>().PlayAudio(AudioType.NAR9, 0.65f);
                        StartCoroutine(WaitForAudioToEnd());
                        break;
                    case "NAR12":
                        GetComponent<AudioManager>().PlayAudio(AudioType.NAR13, 0.65f);
                        StartCoroutine(WaitForAudioToEnd());
                        break;
                    case "NAR13":
                        GetComponent<AudioManager>().PlayAudio(AudioType.NAR14, 0.65f);
                        StartCoroutine(WaitForAudioToEnd());
                        break;
                    case "NAR14":
                        GetComponent<AudioManager>().PlayAudio(AudioType.NAR15, 0.65f);
                        StartCoroutine(WaitForAudioToEnd());
                        break;
                    case "NAR15":
                        GetComponent<AudioManager>().PlayAudio(AudioType.NAR16, 0.65f);
                        StartCoroutine(WaitForAudioToEnd());
                        break;
                    case "NAR16":
                        GetComponent<AudioManager>().PlayAudio(AudioType.NAR17, 0.65f);
                        StartCoroutine(WaitForAudioToEnd());
                        break;
                    default:
                        break;
                }
            }
        }
    }

    void PlayPM1()
    {
        if (GlobalVar.nukeImminent != true)
        {
            GetComponent<AudioManager>().PlayAudio(AudioType.INTRO, 0.65f);
            StartCoroutine(WaitForAudioToEnd());
        }
    }


}
