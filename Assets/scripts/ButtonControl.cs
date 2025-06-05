/////////////////////////////////////////////////////////
//
// Copyright (c) 2025 by arwasairl
//
// This source is provided under the MIT license.
// This software is provided WITHOUT A WARRANTY.
//
// WHAT: Keypad animation player
// DEFINED EXTERNS: 0
// RETURNS: 0
//
/////////////////////////////////////////////////////////


using UnityEngine;
using UnityEngine.Events;

public class ButtonControl : MonoBehaviour
{
    public float pressThreshold = 0.01f;
    public float maxPressDistance = 0.1f;
    public UnityEvent onPressed;

    private Vector3 initialLocalPosition;
    private bool isPressed = false;

    void Start()
    {
        initialLocalPosition = transform.localPosition;
    }

    void Update()
    {
        float displacement = initialLocalPosition.y - transform.localPosition.y;

        if (!isPressed && displacement >= pressThreshold)
        {
            isPressed = true;
            onPressed.Invoke();
        }
        else if (isPressed && displacement < pressThreshold)
        {
            isPressed = false;
        }

        Vector3 clampedPosition = transform.localPosition;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, initialLocalPosition.y - maxPressDistance, initialLocalPosition.y);
        transform.localPosition = clampedPosition;
    }
}
