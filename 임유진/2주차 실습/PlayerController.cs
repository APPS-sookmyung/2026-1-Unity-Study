using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] float torqueAmount = 0.5f;
    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Keyboard.current.leftArrowKey.isPressed)
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if(Keyboard.current.rightArrowKey.isPressed)
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
}
