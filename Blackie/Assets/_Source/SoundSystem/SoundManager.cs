
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource SFXSource;
    public void PlaySound(AudioClip sound)
    {
        SFXSource.PlayOneShot(sound);
    }
}
