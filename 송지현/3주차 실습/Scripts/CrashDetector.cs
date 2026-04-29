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
    void OnTriggerEnter2D(Collider2D Other)
    {
        if(Other.tag == "Ground")
        {
            crashEffect.Play();
            Invoke("ReloadScene", Delay);
        }
    }
      void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

}
