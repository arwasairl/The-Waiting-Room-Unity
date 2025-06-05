/////////////////////////////////////////////////////////
//
// Copyright (c) 2025 by arwasairl
//
// This source is provided under the MIT license.
// This software is provided WITHOUT A WARRANTY.
//
// WHAT: Title text fader
// DEFINED EXTERNS: 0
// RETURNS: line 45 (yield return null)
//
/////////////////////////////////////////////////////////

using TMPro;
using UnityEngine;
using System.Collections;

public class TextFade : MonoBehaviour
{
    public float fadeDuration = 2f;
    private TextMeshPro tmpText;

    private Color originalColor;

    private void Start()
    {
        tmpText = GetComponent<TextMeshPro>();
        originalColor = tmpText.color;

        StartCoroutine(FadeOutAndDisappear());
    }

    private IEnumerator FadeOutAndDisappear()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(originalColor.a, 0f, elapsedTime / fadeDuration);

            Color newColor = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            tmpText.color = newColor;

            yield return null;
        }
        gameObject.SetActive(false);
    }
}
