using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;
using Unity.VisualScripting;


public class CrashDetector : MonoBehaviour
{
    [SerializeField] float Delay= 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    bool d = true;
    void OnTriggerEnter2D(Collider2D Other)
    {
        if(Other.tag == "Ground")
        {
            FindAnyObjectByType<PlayerController>().DisableControls();
            if (d)
            {
                crashEffect.Play();
                GetComponent<AudioSource>().PlayOneShot(crashSFX); 
                Invoke("ReloadScene", Delay);    
                d=false;
                
            }
            
        }
    }
      void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

}
