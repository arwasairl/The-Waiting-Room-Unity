using UnityEngine;

public class PMAnnouncement : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume;

    void Start()
    {
        Invoke("PlayPM1", 5.0f);
    }

    void PlayPM1()
    {
        if (GlobalVar.nukeImminent != true)
        {
            AudioClip clip = Resources.Load<AudioClip>("Audio/pm1");
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}
