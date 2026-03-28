using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;

    void OnTriggerEnter2D(Collider2D other) // other is the object that collided with the player
    {  
        if (other.tag == "Ground") // if the object that collided with the player has the tag "Ground"
        {
            Invoke("ReloadScene", loadDelay); // call the ReloadScene method after a delay of delayBeforeReload seconds
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
