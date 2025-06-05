/////////////////////////////////////////////////////////
//
// Copyright (c) 2025 by arwasairl
//
// This source is provided under the MIT license.
// This software is provided WITHOUT A WARRANTY.
//
// WHAT: Keypad digit display updater
// DEFINED EXTERNS: 0
// RETURNS: 0
//
/////////////////////////////////////////////////////////

using UnityEngine;
using TMPro;
using System.Numerics;

public class KeypadDigits : MonoBehaviour
{
    public TextMeshPro textMesh;
    public static BigInteger keypadvalue;
    void Start()
    {
        UpdateText();
        GlobalVar.Instance.OnArrayChanged += UpdateText;
    }

    void OnDestroy()
    {
        GlobalVar.Instance.OnArrayChanged -= UpdateText;
    }

    void UpdateText()
    {
        int[] array = GlobalVar.Instance.keyPadDigits;

        int count = Mathf.Min(array.Length, 4);
        int startIndex = array.Length - count;

        string result = "";
        for (int i = startIndex; i < array.Length; i++)
        {
            result += array[i].ToString();
        }
        result = result.PadLeft(4, '0');

        if (result.Length > 4)
        {
            result = result.Substring(result.Length - 4);
        }

        string combinedString = string.Join("", GlobalVar.Instance.keyPadDigits);
        keypadvalue = BigInteger.Parse(combinedString);
        Debug.Log(keypadvalue);
        if (keypadvalue == 1243)
        {
            LabdoorUnlock.Instance.Unlock();
        }

        textMesh.text = result;
    }
}