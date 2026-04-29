using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.5f;
    [SerializeField] ParticleSystem finishEffect;

    void OnTriggerEnter2D(Collider2D other) // other is the object that collided with the finish line
    {
        if (other.tag == "Player") // if the object that collided with the finish line has the tag "Player"
        {
            finishEffect.Play(); // play the finish effect
            Invoke("ReloadScene", loadDelay); // call the ReloadScene method after a delay of delayBeforeReload seconds
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
