using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public AudioSource run;
    public AudioSource rune;
    public AudioSource attack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void walkSound()
    {
        run.Play();
    }
    void runSound()
    {
        rune.Play();
    }
    void attackSound()
    {
        attack.Play();
    }
}
