using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Cars : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _moveSpeed = 2.0f;
    [SerializeField] private float _gravity = 15.0f;

    protected virtual void Awake()
    {
        if (GetComponent<Rigidbody>())
        {
            _rb = GetComponent<Rigidbody>();
        }
        else
        { 
            _rb = gameObject.AddComponent<Rigidbody>();
        }

        //_rb.isKinematic = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.MovePosition(transform.position + (Time.deltaTime * _moveSpeed * transform.forward)); //moving forward
                           // + (Vector3.down * Time.deltaTime * _gravity)); ; // custom gravity for kinematic object
    }
}
