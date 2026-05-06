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
            // particle play -> audio play -> reload scene
            finishEffect.Play(); // play the finish effect
            GetComponent<AudioSource>().Play(); // play the audio source attached to the finish line
            Invoke("ReloadScene", loadDelay); // call the ReloadScene method after a delay of delayBeforeReload seconds
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
