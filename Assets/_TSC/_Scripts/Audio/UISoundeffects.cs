using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UISoundeffects : MonoBehaviour
{
    public static UISoundeffects Instance;

    private void Awake()
    {
        Instance = this;
    }

    public AudioSource AudioSource;

    public AudioClip ButtonPressMenu;
    public AudioClip ButtonPressCard;
    public AudioClip OpenCardSelectionSound;

    public AudioClip SelectionFailed;
    public AudioClip[] CardSelection;

    public void CardSelectSound()
    {
        int i = Random.Range(0, CardSelection.Length);
        AudioSource.clip = CardSelection[i];
        AudioSource.Play();
    }
    public void SelectionFailedSound()
    {
        AudioSource.clip = SelectionFailed;
        AudioSource.Play();
    }
    public void ButtonClick()
    {
        AudioSource.clip = ButtonPressMenu;
        AudioSource.Play();
    }
    public void CardClick()
    {
        AudioSource.clip = ButtonPressCard;
        AudioSource.Play();
    }
    public void OpenCardSelection()
    {
        AudioSource.clip = OpenCardSelectionSound;
        AudioSource.Play();
    }
}
