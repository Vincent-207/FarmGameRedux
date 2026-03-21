
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class AudioOneShotManager : MonoBehaviour
{
    public static AudioOneShotManager instance;
    public AudioSource audioSource;
    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
            return;
        }

        instance = this;
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
    }

    public static void PlayOneShot(AudioClip audioClip)
    {
        instance.audioSource.PlayOneShot(audioClip);
    }

    
}
