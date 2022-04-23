using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSounds : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip CardSelected;
    public AudioClip SelectionFailed;

    public void CardSelectSound()
    {
        AudioSource.clip = CardSelected;
        AudioSource.Play();
    }
    public void SelectionFailedSound()
    {
        AudioSource.clip = SelectionFailed;
        AudioSource.Play();
    }
}
