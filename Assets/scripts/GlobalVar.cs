/////////////////////////////////////////////////////////
//
// Copyright (c) 2025 by arwasairl
//
// This source is provided under the MIT license.
// This software is provided WITHOUT A WARRANTY.
//
// WHAT: Global variables
// DEFINED EXTERNS: A lot
// RETURNS: 0
//
/////////////////////////////////////////////////////////

using UnityEngine;
using System;

public class GlobalVar : MonoBehaviour
{
    public static bool breakerFail = false;
    public static bool nukeImminent = false;
    public static bool doorOpen = false;

    public static bool switch1 = false;
    public static bool switch2 = false;
    public static bool switch3 = false;
    public static bool switch4 = false;
    public static bool switch5 = false;
    public static bool switch6 = false;
    public static bool switch7 = false;
    public static bool switch8 = false;
    public static bool switch9 = false;
    public static bool switch10 = false;
    public static bool switch11 = false;
    public static bool switch12 = false;

    public static bool switch13 = false;
    public static bool switch14 = false;
    public static bool switch15 = false;
    public static bool switch16 = false;
    public static bool switch17 = false;
    public static bool switch18 = false;
    public static bool switch19 = false;
    public static bool switch20 = false;
    public static bool switch21 = false;
    public static bool switch22 = false;
    public static bool switch23 = false;
    public static bool switch24 = false;

    public static GlobalVar Instance;

    public int[] keyPadDigits;

    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            keyPadDigits = new int[4];
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void UpdateNumberAtIndex(int newValue)
    {

        int firstElement = keyPadDigits[0];
        for (int i = 0; i < keyPadDigits.Length - 1; i++)
        {
            keyPadDigits[i] = keyPadDigits[i + 1];
        }
        keyPadDigits[keyPadDigits.Length - 1] = newValue;
        OnArrayChanged?.Invoke();
    }

    public void ClearList()
    {
        for (int i = 0; i < keyPadDigits.Length; i++)
        {
            keyPadDigits[i] = 0;
        }
        OnArrayChanged?.Invoke();
    }

    public delegate void ArrayChangedHandler();
    public event ArrayChangedHandler OnArrayChanged;
}
