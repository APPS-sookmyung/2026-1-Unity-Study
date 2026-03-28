using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;


public class CrashDetector : MonoBehaviour
{
    [SerializeField] float Delay= 0.5f;
    void OnTriggerEnter2D(Collider2D Other)
    {
        if(Other.tag == "Ground")
        {
            Invoke("ReloadScene", Delay);
        }
    }
      void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

}
