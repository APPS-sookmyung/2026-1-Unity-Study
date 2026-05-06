using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    bool hasCrashed = false;

    void OnTriggerEnter2D(Collider2D other) // other is the object that collided with the player
    {  
        if (other.tag == "Ground" && !hasCrashed) // if the object that collided with the player has the tag "Ground" and the player hasn't crashed yet
        {
            hasCrashed = true;
            FindAnyObjectByType<PlayerController>()?.DisableControls(); // disable the player's controls 
            crashEffect.Play(); // play the crash effect
            GetComponent<AudioSource>().PlayOneShot(crashSFX); // play the crash sound effect
            Invoke("ReloadScene", loadDelay); // call the ReloadScene method after a delay of delayBeforeReload seconds
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
