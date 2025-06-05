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

        // Clamp the button position
        Vector3 clampedPosition = transform.localPosition;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, initialLocalPosition.y - maxPressDistance, initialLocalPosition.y);
        transform.localPosition = clampedPosition;
    }
}
