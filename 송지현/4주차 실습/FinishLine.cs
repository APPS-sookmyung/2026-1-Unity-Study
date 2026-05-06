using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float Delay=1f;
    [SerializeField] ParticleSystem finishEffect;
    
    
    void OnTriggerEnter2D(Collider2D Other)
    {

        if(Other.tag == "Player")
        {
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", Delay);
            
            
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

}

