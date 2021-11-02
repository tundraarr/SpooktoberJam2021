using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource laugh;
    public AudioSource shoot;
    public AudioSource sacrifice;
    public AudioSource hitsound;

    public void PlayLaugh()
    {
        laugh.Play();
    }

    public void PlayShoot()
    {
        shoot.Play();
    }

    public void PlaySacrifice()
    {
        sacrifice.Play();
    }

    public void PlayHitSound()
    {
        hitsound.Play();
    }
}
