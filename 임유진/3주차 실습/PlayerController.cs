using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] float torqueAmount = 0.5f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;

    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindAnyObjectByType<SurfaceEffector2D>();
    }

    void Update()
    {
        RotatePlayer();
        RespondToBoost();
    }

    void RespondToBoost()
    {
        // if we push up, then speed up
        // otherwise stay at normal speed
        // access the surfaceeffector2d and change its speed
        if (Keyboard.current.upArrowKey.isPressed)
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
}
