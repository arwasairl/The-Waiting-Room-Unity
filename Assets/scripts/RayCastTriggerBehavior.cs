
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class RayCastTriggerBehavior : MonoBehaviour
{
    public XRRayInteractor rayInteractor;
    public InputActionProperty activateAction;
    public GameObject METALGATE;
    private bool wasPressed = false;

    void Update()
    {
        bool isPressed = activateAction.action.ReadValue<float>() > 0.1f;

        if (isPressed && !wasPressed)
        {
            TryRotateHitObject();
            TryPressButtonObject();
        }

        wasPressed = isPressed;
    }

    void TryPressButtonObject()
    {
        if (rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            Transform target = hit.transform;
            ButtonAnim buttonA = target.GetComponent<ButtonAnim>();
            if (target.CompareTag("Button"))
            {
                if (buttonA != null && buttonA.isAnimating)
                {
                    return;
                }
                string buttonName = target.name.ToLower();

                switch (buttonName)
                {
                    case "0":
                        GlobalVar.Instance.UpdateNumberAtIndex(0);
                        break;
                    case "1":
                        GlobalVar.Instance.UpdateNumberAtIndex(1);
                        break;
                    case "2":
                        GlobalVar.Instance.UpdateNumberAtIndex(2);
                        break;
                    case "3":
                        GlobalVar.Instance.UpdateNumberAtIndex(3);
                        break;
                    case "4":
                        GlobalVar.Instance.UpdateNumberAtIndex(4);
                        break;
                    case "5":
                        GlobalVar.Instance.UpdateNumberAtIndex(5);
                        break;
                    case "6":
                        GlobalVar.Instance.UpdateNumberAtIndex(6);
                        break;
                    case "7":
                        GlobalVar.Instance.UpdateNumberAtIndex(7);
                        break;
                    case "8":
                        GlobalVar.Instance.UpdateNumberAtIndex(8);
                        break;
                    case "9":
                        GlobalVar.Instance.UpdateNumberAtIndex(9);
                        break;
                    case "enter":
                        METALGATE.SetActive(false);
                        break;
                    case "pound":
                        GlobalVar.Instance.ClearList();
                        break;
                    default:
                        break;
                }
                StartCoroutine(PressButtonAnimation(target, buttonA, 0.02f, 0.2f));
                AudioSource audio = target.GetComponent<AudioSource>();
                if (audio != null) audio.Play();
            }
        }
    }

    private IEnumerator PressButtonAnimation(Transform target, ButtonAnim buttonA, float pressDepth, float returnDuration)
    {
        if (buttonA != null)
        {
            buttonA.isAnimating = true;
        }

        // Instantly move down
        Vector3 depressedPos = buttonA.originalLocalPosition + new Vector3(0, 0, -pressDepth);
        target.localPosition = depressedPos;

        // Slowly return to original position
        float elapsed = 0f;
        while (elapsed < returnDuration)
        {
            target.localPosition = Vector3.Lerp(depressedPos, buttonA.originalLocalPosition, elapsed / returnDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        target.localPosition = buttonA.originalLocalPosition;

        if (buttonA != null)
        {
            buttonA.isAnimating = false;
        }
    }

    void TryRotateHitObject()
    {
        if (rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            Transform target = hit.transform;

            if (target.CompareTag("Switch"))
            {
                string switchName = target.name.ToLower(); // e.g., "switch1", "switch2"

                switch (switchName)
                {
                    case "switch1":
                        if (GlobalVar.switch1 == false)
                        {
                            target.Rotate(0f, 60f, 0f);
                        }
                        else
                        {
                            target.Rotate(0f, -60f, 0f);
                        }
                        GlobalVar.switch1 = !GlobalVar.switch1;
                        break;
                    case "switch2":
                        if (GlobalVar.switch2 == false)
                        {
                            GlobalVar.breakerFail = true;
                            target.Rotate(0f, 60f, 0f);
                        }
                        else
                        {
                            target.Rotate(0f, -60f, 0f);
                        }
                        GlobalVar.switch2 = !GlobalVar.switch2;
                        break;
                    case "switch3":
                        if (GlobalVar.switch3 == false)
                        {
                            target.Rotate(0f, 60f, 0f);
                        }
                        else
                        {
                            target.Rotate(0f, -60f, 0f);
                        }
                        GlobalVar.switch3 = !GlobalVar.switch3;
                        break;
                    case "switch4":
                        if (GlobalVar.switch4 == false)
                        {
                            target.Rotate(0f, 60f, 0f);
                        }
                        else
                        {
                            target.Rotate(0f, -60f, 0f);
                        }
                        GlobalVar.switch4 = !GlobalVar.switch4;
                        break;
                    case "switch5":
                        if (GlobalVar.switch5 == false)
                        {
                            GlobalVar.breakerFail = true;
                            target.Rotate(0f, 60f, 0f);
                        }
                        else
                        {
                            target.Rotate(0f, -60f, 0f);
                        }
                        GlobalVar.switch5 = !GlobalVar.switch5;
                        break;
                    case "switch6":
                        if (GlobalVar.switch6 == false)
                        {
                            GlobalVar.breakerFail = true;
                            target.Rotate(0f, 60f, 0f);
                        }
                        else
                        {
                            target.Rotate(0f, -60f, 0f);
                        }
                        GlobalVar.switch6 = !GlobalVar.switch6;
                        break;
                    case "switch7":
                        if (GlobalVar.switch7 == false)
                        {
                            GlobalVar.breakerFail = true;
                            target.Rotate(0f, 60f, 0f);
                        }
                        else
                        {
                            target.Rotate(0f, -60f, 0f);
                        }
                        GlobalVar.switch7 = !GlobalVar.switch7;
                        break;
                    case "switch8":
                        if (GlobalVar.switch8 == false)
                        {
                            target.Rotate(0f, 60f, 0f);
                        }
                        else
                        {
                            target.Rotate(0f, -60f, 0f);
                        }
                        GlobalVar.switch8 = !GlobalVar.switch8;
                        break;
                    case "switch9":
                        if (GlobalVar.switch9 == false)
                        {
                            target.Rotate(0f, 60f, 0f);
                        }
                        else
                        {
                            target.Rotate(0f, -60f, 0f);
                        }
                        GlobalVar.switch9 = !GlobalVar.switch9;
                        break;
                    case "switch10":
                        if (GlobalVar.switch10 == false)
                        {
                            GlobalVar.breakerFail = true;
                            target.Rotate(0f, 60f, 0f);
                        }
                        else
                        {
                            target.Rotate(0f, -60f, 0f);
                        }
                        GlobalVar.switch10 = !GlobalVar.switch10;
                        break;
                    case "switch11":
                        if (GlobalVar.switch11 == false)
                        {
                            target.Rotate(0f, 60f, 0f);
                        }
                        else
                        {
                            target.Rotate(0f, -60f, 0f);
                        }
                        GlobalVar.switch11 = !GlobalVar.switch11;
                        break;
                    case "switch12":
                        if (GlobalVar.switch12 == false)
                        {
                            GlobalVar.breakerFail = true;
                            target.Rotate(0f, 60f, 0f);
                        }
                        else
                        {
                            target.Rotate(0f, -60f, 0f);
                        }
                        GlobalVar.switch12 = !GlobalVar.switch12;
                        break;
                    case "switch13":
                        if (GlobalVar.switch13 == false)
                        {
                            GlobalVar.breakerFail = true;
                            target.Rotate(0f, 60f, 0f);
                        }
                        else
                        {
                            target.Rotate(0f, -60f, 0f);
                        }
                        GlobalVar.switch13 = !GlobalVar.switch13;
                        break;
                    case "switch14":
                        if (GlobalVar.switch14 == false)
                        {
                            target.Rotate(0f, 60f, 0f);
                        }
                        else
                        {
                            target.Rotate(0f, -60f, 0f);
                        }
                        GlobalVar.switch14 = !GlobalVar.switch14;
                        break;
                    case "switch15":
                        if (GlobalVar.switch15 == false)
                        {
                            target.Rotate(0f, 60f, 0f);
                        }
                        else
                        {
                            target.Rotate(0f, -60f, 0f);
                        }
                        GlobalVar.switch15 = !GlobalVar.switch15;
                        break;
                    case "switch16":
                        if (GlobalVar.switch16 == false)
                        {
                            GlobalVar.breakerFail = true;
                            target.Rotate(0f, 60f, 0f);
                        }
                        else
                        {
                            target.Rotate(0f, -60f, 0f);
                        }
                        GlobalVar.switch16 = !GlobalVar.switch16;
                        break;
                    case "switch17":
                        if (GlobalVar.switch17 == false)
                        {
                            target.Rotate(0f, 60f, 0f);
                        }
                        else
                        {
                            target.Rotate(0f, -60f, 0f);
                        }
                        GlobalVar.switch17 = !GlobalVar.switch17;
                        break;
                    case "switch18":
                        if (GlobalVar.switch18 == false)
                        {
                            target.Rotate(0f, 60f, 0f);
                        }
                        else
                        {
                            target.Rotate(0f, -60f, 0f);
                        }
                        GlobalVar.switch18 = !GlobalVar.switch18;
                        break;
                    case "switch19":
                        if (GlobalVar.switch19 == false)
                        {
                            target.Rotate(0f, 60f, 0f);
                        }
                        else
                        {
                            target.Rotate(0f, -60f, 0f);
                        }
                        GlobalVar.switch19 = !GlobalVar.switch19;
                        break;
                    case "switch20":
                        if (GlobalVar.switch20 == false)
                        {
                            GlobalVar.breakerFail = true;
                            target.Rotate(0f, 60f, 0f);
                        }
                        else
                        {
                            target.Rotate(0f, -60f, 0f);
                        }
                        GlobalVar.switch20 = !GlobalVar.switch20;
                        break;
                    case "switch21":
                        if (GlobalVar.switch21 == false)
                        {
                            GlobalVar.breakerFail = true;
                            target.Rotate(0f, 60f, 0f);
                        }
                        else
                        {
                            target.Rotate(0f, -60f, 0f);
                        }
                        GlobalVar.switch21 = !GlobalVar.switch21;
                        break;
                    case "switch22":
                        if (GlobalVar.switch22 == false)
                        {
                            GlobalVar.breakerFail = true;
                            target.Rotate(0f, 60f, 0f);
                        }
                        else
                        {
                            target.Rotate(0f, -60f, 0f);
                        }
                        GlobalVar.switch22 = !GlobalVar.switch22;
                        break;
                    case "switch23":
                        if (GlobalVar.switch23 == false)
                        {
                            GlobalVar.breakerFail = true;
                            target.Rotate(0f, 60f, 0f);
                        }
                        else
                        {
                            target.Rotate(0f, -60f, 0f);
                        }
                        GlobalVar.switch23 = !GlobalVar.switch23;
                        break;
                    case "switch24":
                        if (GlobalVar.switch24 == false)
                        {
                            GlobalVar.breakerFail = true;
                            target.Rotate(0f, 60f, 0f);
                        }
                        else
                        {
                            target.Rotate(0f, -60f, 0f);
                        }
                        GlobalVar.switch24 = !GlobalVar.switch24;
                        break;
                    default:
                        Debug.LogWarning($"Unhandled switch: {switchName}");
                        break;

                }
                AudioSource audio = target.GetComponent<AudioSource>();
                if (audio != null)
                {
                    audio.Play();
                }

                if (GlobalVar.switch1 && GlobalVar.switch3 && GlobalVar.switch4 && GlobalVar.switch8 && GlobalVar.switch9 && GlobalVar.switch11 && GlobalVar.switch14 && GlobalVar.switch15 && GlobalVar.switch17 && GlobalVar.switch18 && GlobalVar.switch19)
                {
                    GlobalVar.doorOpen = true;
                    DoorLock.Instance.Unlock();
                }

            }
        }
    }
}
