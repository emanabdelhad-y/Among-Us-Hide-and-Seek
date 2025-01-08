using UnityEngine;
using UnityEngine.Windows;

public class AudioManager : MonoBehaviour
{

    [Header("_________ Audio Source _________")]
    [SerializeField] AudioSource SFXSource;

    [Header("_________ Audio Clip _________")]
    public AudioClip walking;
    public void PlayWalkingSound(AudioClip clip, float xInput, float yInput)
    {
        if ((xInput != 0 || yInput != 0 ))
        { 
            SFXSource.clip = clip;
            SFXSource.enabled = true;
        }
        else
        {
            SFXSource.enabled = false;
        }
    }

}
