using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Cars : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _moveSpeed = 2.0f;
    [SerializeField] private float _gravity = 15.0f;

    [Header("Scene objects")]
    [SerializeField] Vector3 _transformRespawnPoint;
    protected virtual void Awake()
    {
        _transformRespawnPoint = transform.position;

        if (GetComponent<Rigidbody>())
        {
            _rb = GetComponent<Rigidbody>();
        }
        else
        { 
            _rb = gameObject.AddComponent<Rigidbody>();
        }

        //wanted this to be kinematic but leaving it as non kinematic for this test
        //_rb.isKinematic = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.MovePosition(transform.position + (Time.deltaTime * _moveSpeed * transform.forward)); //moving forward
    }

    public void ResetPosition()
    {
        _rb.Sleep();
        transform.position = _transformRespawnPoint;
    }
}
