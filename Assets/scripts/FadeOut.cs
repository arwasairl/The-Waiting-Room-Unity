/////////////////////////////////////////////////////////
//
// Copyright (c) 2025 by arwasairl
//
// This source is provided under the MIT license.
// This software is provided WITHOUT A WARRANTY.
//
// WHAT: Fade in intro black object
// DEFINED EXTERNS: 0
// RETURNS: line 49 yield return null
//
/////////////////////////////////////////////////////////

using UnityEngine;

namespace System.Collections
{
    public class FadeOut : MonoBehaviour
    {
        public GameObject UI;
        public GameObject UI2;
        public float fadeDuration = 2f;
        private Material material;
        private Color originalColor;

        private void Start()
        {
            UI.SetActive(false);
            UI2.SetActive(false);
            material = GetComponent<Renderer>().material;
            originalColor = material.color;

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
                material.color = newColor;

                yield return null;
            }

            gameObject.SetActive(false);
        }
    }

}