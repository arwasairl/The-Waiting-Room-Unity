/////////////////////////////////////////////////////////
//
// Copyright (c) 2025 by arwasairl
//
// This source is provided under the MIT license.
// This software is provided WITHOUT A WARRANTY.
//
// WHAT: Clock incrementer and display
// DEFINED EXTERNS: 0
// RETURNS: line 70 (void return)
//
/////////////////////////////////////////////////////////

using System;
using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public TextMeshPro clockDisplay;
    private float elapsedTime = 0f;
    private bool isRunning = true;
    public ParticleSystem ps;
    public Renderer blackScreen;
    public GameObject shell;
    private Material targetMaterial;
    public Light nolight;
    public GameObject UI;
    public bool clockchanged = false;
    public GameObject player;
    void Start()
    {
        clockDisplay = GetComponent<TextMeshPro>();
        ps.Stop();
        ps.gameObject.SetActive(false);

    }

    void OnEnable()
    {
        Detection.OnCollision += changeClock;
    }

    void OnDisable()
    {
        Detection.OnCollision -= changeClock;
    }

    void changeClock(GameObject collidedObject)
    {
        elapsedTime = 27.46f;
        clockchanged = true;
    }

    void Update()
    {
        if (GlobalVar.breakerFail == true && clockchanged == false)
        {
            changeClock(null);
        }
        if (GlobalVar.nukeImminent != true)
        {
            elapsedTime += Time.unscaledDeltaTime;
            string minutes = (Mathf.Floor(elapsedTime / 60) + 31).ToString("00");
            string seconds = Mathf.Floor(elapsedTime % 60).ToString("00");
            clockDisplay.text = "10:" + minutes + ":" + seconds;
        }
        else
        {
            if (!isRunning)
                return;

            elapsedTime -= Time.unscaledDeltaTime;

            if (elapsedTime <= 0f)
            {
                elapsedTime = 0f;
                isRunning = false;
                ps.gameObject.SetActive(true);
                ps.Play();
                shell.SetActive(true);
                player.transform.position = new Vector3(0.99f, 1.535f, -5.541f);
                targetMaterial = blackScreen.material;
                Color color = targetMaterial.color;
                color.a = 1f;
                targetMaterial.color = color;
                Invoke("killExp", 1.0f);
                Invoke("reloadPrompt", 2.0f);
            }
            int seconds = Mathf.FloorToInt(elapsedTime % 60);
            int milliseconds = Mathf.FloorToInt((elapsedTime % 1) * 1000);
            clockDisplay.text = "0:" + string.Format("{0:00}:{1:000}", seconds, milliseconds);
        }
    }

    void killExp()
    {
        nolight.enabled = false;
        ps.Stop();
        ps.gameObject.SetActive(false);
    }

    void reloadPrompt()
    {
        UI.SetActive(true);
    }

}
