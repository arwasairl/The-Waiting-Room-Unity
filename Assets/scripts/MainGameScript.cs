/////////////////////////////////////////////////////////
//
// Copyright (c) 2025 by arwasairl
//
// This source is provided under the MIT license.
// This software is provided WITHOUT A WARRANTY.
//
// WHAT: Main game script (misc features)
// DEFINED EXTERNS: 0
// RETURNS: 0
//
/////////////////////////////////////////////////////////

using UnityEditor;
using UnityEngine;

public class MainGameScript : MonoBehaviour
{
    public GameObject UI2;
    public Light nolight;
    public GameObject shell;
    public GameObject player;
    private Material targetMaterial;
    public Renderer blackScreen;
    void Start()
    {
        Invoke("timesUp", 600.0f);
    }

    void timesUp()
    {
        if (GlobalVar.nukeImminent != true && GlobalVar.breakerFail != true && GlobalVar.doorOpen != true)
        {
            nolight.enabled = false;
            shell.SetActive(true);
            UI2.SetActive(true);
            player.transform.position = new Vector3(0.99f, 1.535f, -5.541f);
            targetMaterial = blackScreen.material;
            Color color = targetMaterial.color;
            color.a = 1f;
            targetMaterial.color = color;
        }
    }


}
