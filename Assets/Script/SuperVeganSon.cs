using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperVeganSon : MonoBehaviour
{
    private AudioSource sv;
    public AudioClip cour;
    public AudioClip saut;
    public AudioClip coup;
    public AudioClip lowkik;
    private CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        sv = GetComponent<AudioSource>();
        controller = GetComponent<CharacterController>();

    }

    public void Courir()
    {
        if ((sv.loop == false) & (controller.isGrounded))
        {
            sv.clip = cour;
            sv.Play();
            sv.loop = true;


        }
    }

    public void Kick()
    {
        sv.Stop();
        sv.loop = false;
        sv.clip = coup;
        sv.Play();
    }

    public void LowKick()
    {
        sv.Stop();
        sv.loop = false;
        sv.clip = lowkik;
        sv.Play();
    }

    public void Repos()
    {
        sv.loop = false;
        sv.Stop();

    }

    public void Jump()
    {
        sv.loop = false;
        if (sv.clip != saut)
        {
            sv.Stop();
            
            sv.clip = saut;
            sv.Play();
        }

    }
}
