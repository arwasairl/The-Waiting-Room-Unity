/////////////////////////////////////////////////////////
//
// Copyright (c) 2025 by arwasairl
//
// This source is provided under the MIT license.
// This software is provided WITHOUT A WARRANTY.
//
// WHAT: Waiting room door lock 
// DEFINED EXTERNS: Instance
// RETURNS: 0
//
/////////////////////////////////////////////////////////

using UnityEngine;
using UnityEngine.Audio;
public class DoorLock : MonoBehaviour
{
    public static DoorLock Instance;
    private AudioSource audioSource;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        HingeJoint hinge = GetComponent<HingeJoint>();
        if (hinge != null)
        {
            JointLimits limits = hinge.limits;
            limits.min = 0;
            limits.max = 0;
            hinge.limits = limits;
            hinge.useLimits = true;
        }
    }

    public void Unlock()
    {
        HingeJoint hinge = GetComponent<HingeJoint>();
        if (hinge != null)
        {
            JointLimits limits = hinge.limits;
            limits.min = -100;
            limits.max = 100;
            hinge.limits = limits;
            hinge.useLimits = true;
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            foreach (AudioManager am in GlobalVar.speakers)
            {
                if (am.audiosource.isPlaying == true)
                {
                    GlobalVar.narratorCutoff = true;
                    am.audiosource.Stop();
                    am.PlayAudio(AudioType.NARHEY, 0.50f);
                    GlobalVar.narratorCutoff = false;
                    StartCoroutine(am.WaitForAudioToEnd());
                }
                else
                {
                    am.PlayAudio(AudioType.NAR7, 0.60f);
                }
            }
        }
    }

}
