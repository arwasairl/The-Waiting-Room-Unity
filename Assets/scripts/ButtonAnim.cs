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
