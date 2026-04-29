using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem crashEffect;

    void OnTriggerEnter2D(Collider2D other) // other is the object that collided with the player
    {  
        if (other.tag == "Ground") // if the object that collided with the player has the tag "Ground"
        {
            crashEffect.Play(); // play the crash effect
            Invoke("ReloadScene", loadDelay); // call the ReloadScene method after a delay of delayBeforeReload seconds
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
