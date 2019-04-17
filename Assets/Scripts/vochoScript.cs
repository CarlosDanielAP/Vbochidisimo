using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vochoScript : MonoBehaviour
    
{
    public bool onGround;
    public bool perdiste;
    public bool volar;

    private void Start()
    {
        perdiste = false;
        volar = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            Debug.Log("perdiste");
            perdiste = true;
        }
        if (other.gameObject.tag == "paloma")
        {
            Debug.Log("reypalomo");
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
            
            onGround = false;
        }
       

    }
}
