using UnityEngine;
using UnityEngine.Audio;

public class DoorLock : MonoBehaviour
{
    public static DoorLock Instance;
    private AudioSource audioSource;
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        HingeJoint hinge = GetComponent<HingeJoint>();
        if (hinge != null)
        {
            JointLimits limits = hinge.limits;
            limits.min = 0;
            limits.max = 0;
            hinge.limits = limits;

            hinge.useLimits = true;
        }
    }

    public void Unlock()
    {
        HingeJoint hinge = GetComponent<HingeJoint>();
        if (hinge != null)
        {
            JointLimits limits = hinge.limits;
            limits.min = -100;
            limits.max = 100;
            hinge.limits = limits;
            hinge.useLimits = true;
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }
    }

}
