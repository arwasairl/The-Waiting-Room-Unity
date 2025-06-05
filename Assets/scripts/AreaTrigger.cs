/////////////////////////////////////////////////////////
//
// Copyright (c) 2025 by arwasairl
//
// This source is provided under the MIT license.
// This software is provided WITHOUT A WARRANTY.
//
// WHAT:Player detection on an area
// DEFINED EXTERNS: 0
// RETURNS: 0
//
/////////////////////////////////////////////////////////

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;


public class XRTriggerZone : MonoBehaviour
{
    public GameObject areaTrigger;
    public Light nolight;
    public GameObject shell;
    public GameObject player;
    public Material targetMaterial;
    public Renderer blackScreen;
    public AudioSource shellSource;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GlobalVar.doorOpen == true)
        {
            switch(areaTrigger.name)
            {
                case "Area1":
                    if (GlobalVar.area1Entered == false)
                    {
                        GlobalVar.area1Entered = true;
                        foreach (AudioManager am in GlobalVar.speakers)
                        {
                            if (am.audiosource.isPlaying == true)
                            {
                                am.audiosource.Stop();
                            }
                            am.PlayAudio(AudioType.NAR8, 0.60f);
                            StartCoroutine(am.WaitForAudioToEnd());
                        }
                    }
                    break;
                case "Area2":
                    if (GlobalVar.area2Entered == false && GlobalVar.LabDoorUnlocked == false)
                    {
                        GlobalVar.area2Entered = true;
                        if (GlobalVar.area3Entered == true)
                        {
                            foreach (AudioManager am in GlobalVar.speakers)
                            {
                                if (am.audiosource.isPlaying == true)
                                {
                                    GlobalVar.narratorCutoff = true;
                                    am.audiosource.Stop();
                                }
                                am.PlayAudio(AudioType.NAR12, 0.60f);
                                GlobalVar.narratorCutoff = false;
                                StartCoroutine(am.WaitForAudioToEnd());
                            }
                        }
                        else
                        {
                            foreach (AudioManager am in GlobalVar.speakers)
                            {
                                if (am.audiosource.isPlaying == true)
                                {
                                    GlobalVar.narratorCutoff = true;
                                    am.audiosource.Stop();
                                }
                                am.PlayAudio(AudioType.NAR10, 0.60f);
                                GlobalVar.narratorCutoff = false;
                                StartCoroutine(am.WaitForAudioToEnd());
                            }
                        }
                    }
                    break;
                case "Area3":
                    if (GlobalVar.area3Entered == false && GlobalVar.LabDoorUnlocked == false)
                    {
                        GlobalVar.area3Entered = true;
                        if (GlobalVar.area2Entered == true)
                        {
                            foreach (AudioManager am in GlobalVar.speakers)
                            {
                                if (am.audiosource.isPlaying == true)
                                {
                                    GlobalVar.narratorCutoff = true;
                                    am.audiosource.Stop();
                                }
                                am.PlayAudio(AudioType.NAR12, 0.60f);
                                GlobalVar.narratorCutoff = false;
                                StartCoroutine(am.WaitForAudioToEnd());
                            }
                        }
                        else
                        {
                            foreach (AudioManager am in GlobalVar.speakers)
                            {
                                if (am.audiosource.isPlaying == true)
                                {
                                    GlobalVar.narratorCutoff = true;
                                    am.audiosource.Stop();
                                }
                                am.PlayAudio(AudioType.NAR11, 0.60f);
                                GlobalVar.narratorCutoff = false;
                                StartCoroutine(am.WaitForAudioToEnd());
                            }
                        }
                    }
                    break;
                case "Area4":
                    if (GlobalVar.area4Entered == false)
                    {
                        GlobalVar.area4Entered = true;
                        foreach (AudioManager am in GlobalVar.speakers)
                        {
                            if (am.audiosource.isPlaying == true)
                            {
                                GlobalVar.narratorCutoff = true;
                                am.audiosource.Stop();
                            }
                            am.PlayAudio(AudioType.NAR19, 0.60f);
                            GlobalVar.narratorCutoff = false;
                            StartCoroutine(am.WaitForAudioToEnd());
                        }
                    }
                    break;
                case "Area5":

                    if (GlobalVar.area5Entered == false)
                    {
                        GlobalVar.area5Entered = true;
                        foreach (AudioManager am in GlobalVar.speakers)
                        {
                            if (am.audiosource.isPlaying == true)
                            {
                                GlobalVar.narratorCutoff = true;
                                am.audiosource.Stop();
                            }
                        }
                        AudioSource[] allAudioSources = FindObjectsByType<AudioSource>(FindObjectsSortMode.None);

                        foreach (AudioSource audioSource in allAudioSources)
                        {
                            audioSource.Stop();
                        }
                        nolight.enabled = false;
                        shell.SetActive(true);
                        player.transform.position = new Vector3(0.99f, 1.535f, -5.541f);
                        targetMaterial = blackScreen.material;
                        Color color = targetMaterial.color;
                        color.a = 1f;
                        targetMaterial.color = color;
                        GlobalVar.area5Entered = true;
                        Invoke("monologue", 3.0f);
                    }
                    break;
                default:
                    break;
            }
        }
    }

    private void monologue()
    {
        Invoke("quit", 28.0f);
        shellSource.Play();
    }

    private void quit()
    {
        Application.Quit();
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        Debug.Log("XR Player exited the trigger zone.");
    //    }
    //}
}