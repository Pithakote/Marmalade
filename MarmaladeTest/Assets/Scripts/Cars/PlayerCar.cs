using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInputHandler))]
public class PlayerCar : Cars
{
    [SerializeField] private PlayerInputHandler _inputHandler;
    [SerializeField] private float _rotationSpeed = 30.0f;

    protected override void Awake()
    {
        base.Awake();
        _inputHandler = GetComponent<PlayerInputHandler>();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        //add code to smoothly turn in Y axis
        if (_inputHandler.IsClicked == false)
        {
            return;
        }

        //looked at the code from here : https://forum.unity.com/threads/rotate-rigidbody-to-face-cursor-position-on-screen.570124/
        _rb.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_inputHandler.MouseClickPosition - transform.position), _rotationSpeed * Time.deltaTime);
    }
}
