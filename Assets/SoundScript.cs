using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public AudioSource walk;
    public AudioSource run;
    public AudioSource attack;

    void walkSound()
    {
        run.Play();
    }
    void runSound()
    {
        run.Play();
    }
    void attackSound()
    {
        attack.Play();
    }
}
