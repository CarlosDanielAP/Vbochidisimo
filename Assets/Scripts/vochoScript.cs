using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vochoScript : MonoBehaviour
    
{
    public ParticleSystem particulaschoque;
    public AudioClip choque;
    public AudioClip salto;
    public AudioClip paloma;
    AudioSource audiovocho;
    public bool onGround;
    public bool perdiste;
    public bool volar;
    public GameObject vocho;
    public GameObject alitas;

    private void Start()
    {
        audiovocho=GetComponent<AudioSource>();
        perdiste = false;
        volar = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            particulaschoque.GetComponent<ParticleSystem>().Play();
            Debug.Log("perdiste");
            audiovocho.clip = choque;
            audiovocho.Play();
            perdiste = true;
            alitas.SetActive(false);
            vocho.SetActive(false);
        }
        if (other.gameObject.tag == "paloma")
        {
            Debug.Log("reypalomo");
            audiovocho.clip = paloma;
            audiovocho.Play();
            Destroy(other.gameObject);
            volar = true;
           
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("piso");
            onGround = true;
            perdiste = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            audiovocho.clip = salto;
            audiovocho.Play();
            onGround = false;
        }
       

    }
}
