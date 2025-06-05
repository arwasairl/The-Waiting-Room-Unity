/////////////////////////////////////////////////////////
//
// Copyright (c) 2025 by arwasairl
//
// This source is provided under the MIT license.
// This software is provided WITHOUT A WARRANTY.
//
// WHAT: Keypad animation setter
// DEFINED EXTERNS: 0
// RETURNS: 0
//
/////////////////////////////////////////////////////////

using UnityEngine;

public class ButtonAnim : MonoBehaviour
{
    public bool isAnimating = false;
    [HideInInspector] public Vector3 originalLocalPosition;

    void Awake()
    {
        originalLocalPosition = transform.localPosition;
    }
}
