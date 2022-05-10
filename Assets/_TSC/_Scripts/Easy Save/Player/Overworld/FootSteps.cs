using UnityEngine;

public class FootSteps : MonoBehaviour
{
    //Array of clips
    [SerializeField]
    private AudioClip[] clips;
    private AudioSource audioSource;

    //links to the Component AudioSource
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    //Gets random AudioClip and plays it
    private void Step()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }

    //returns a random AudioClip from the total soundlibary array
    private AudioClip GetRandomClip()
    {
        return clips[UnityEngine.Random.Range(0, clips.Length)];
    }
}