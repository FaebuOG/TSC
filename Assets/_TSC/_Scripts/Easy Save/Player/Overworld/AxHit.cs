
using UnityEngine;
using UnityEngine.InputSystem;
public class AxHit : MonoBehaviour
{
    //Axe Audio fields
    [SerializeField]
    private AudioClip[] clips;
    private AudioSource audioSource;

    //Axe fields
    public GameObject objectToDeactivate;
    private bool isvisible;

    //links to the Component AudioSource
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        //if Event PreAxHit has happed then the selected Object will be activated
        if (isvisible == true)
        {
            objectToDeactivate.SetActive(true);
        }
        //if Event AfterAxHit has happed then the selected Object will be deactivated
        if (isvisible == false)
        {
            objectToDeactivate.SetActive(false);
        }
    }

    /*private bool NewEvent()
    {
        Debug.Log("New event");
        return actionTriggert = true;
    }*/
    //retruns the bool of the visibility of the object to true
    private bool PreAxHit()
    {   
        Debug.Log("PreAxHit");
        return isvisible = true;
    }
    //Gets random AudioClip and plays it
    private void Hit()
    {
        Debug.Log("Hit");
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }
    //retruns the bool of the visibility of the object to false
    private bool AfterAxHit()
    {
        Debug.Log("AfterAxHit");
        return isvisible = false;
    }

    //returns a random AudioClip from the total soundlibary array
    private AudioClip GetRandomClip()
    {
        return clips[UnityEngine.Random.Range(0, clips.Length)];
    }
}